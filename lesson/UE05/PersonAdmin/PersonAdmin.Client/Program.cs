using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dal.Common;
using Microsoft.Extensions.Configuration;
using PersonAdmin.Dal.Ado;
using PersonAdmin.Dal.Interface;
using PersonAdmin.Dal.Simple;

namespace PersonAdmin.Client
{
    internal class DalTester
    {
        #region Private Fields

        private readonly IPersonDao personDao;

        #endregion

        #region Internal Constructors

        internal DalTester(IPersonDao personDao)
        {
            this.personDao = personDao;
        }

        #endregion

        #region Internal Methods

        internal async Task TestFindAllAsync()
        {
            (await personDao.FindAllAsync())
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Id,5} | {p.FirstName,-10} | {p.LastName,-15} | {p.DateOfBirth:yyyy-MM-dd}"));
        }

        internal async Task TestFindByIdAsync()
        {
            var person1 = await personDao.FindByIdAsync(1);
            Console.WriteLine($"FindById(1) {person1?.ToString() ?? "<null>"}");

            var person2 = await personDao.FindByIdAsync(999);
            Console.WriteLine($"FindById(999) {person2?.ToString() ?? "<null>"}");
        }

        internal async Task TestUpdateAsync()
        {
            var person = await personDao.FindByIdAsync(1);
            Console.WriteLine($"Before update -> {person?.ToString() ?? "<null>"}");
            if (person is null)
            {
                return;
            }
            person.DateOfBirth = person.DateOfBirth.AddYears(1);
            await personDao.UpdateAsync(person);

            person = await personDao.FindByIdAsync(1);
            Console.WriteLine($"After update -> {person?.ToString() ?? "<null>"}");
        }

        internal async Task TestTransactionsAsync()
        {
            var person1 = await personDao.FindByIdAsync(1);
            var person2 = await personDao.FindByIdAsync(2);
            Console.WriteLine($"Before transaction: person1 -> {person1?.ToString() ?? "<null>"}");
            Console.WriteLine($"Before transaction: person2 -> {person2?.ToString() ?? "<null>"}");

            try
            {
                using TransactionScope scope = new(TransactionScopeAsyncFlowOption.Enabled);
                person1.DateOfBirth = person1.DateOfBirth.AddYears(1);
                await personDao.UpdateAsync(person1);
                //throw new ArgumentException();
                person2.DateOfBirth = person2.DateOfBirth.AddYears(1);
                await personDao.UpdateAsync(person2);
                scope.Complete();

            }
            catch (Exception)
            {
                Console.WriteLine("Transaction rolled back");
            }

            person1 = await personDao.FindByIdAsync(1);
            person2 = await personDao.FindByIdAsync(2);
            Console.WriteLine($"After transaction: person1 -> {person1?.ToString() ?? "<null>"}");
            Console.WriteLine($"After transaction: person2 -> {person2?.ToString() ?? "<null>"}");
        }

        #endregion
    }

    internal class Program
    {
        #region Private Methods

        private const string CONNECTION_CONFIGURATION = "PersonDbConnection";

        private static async Task Main()
        {
            PrintTitle("SimplePersonDao.FindAll()");
            DalTester tester1 = new(new SimplePersonDao());
            await tester1.TestFindAllAsync();

            PrintTitle("SimplePersonDao.FindById()");
            await tester1.TestFindByIdAsync();

            PrintTitle("SimplePersonDao.Update()");
            await tester1.TestUpdateAsync();

            IConfiguration configuration = ConfigurationUtil.GetConfiguration();
            IConnectionFactory factory = DefaultConnectionFactory.FromConfiguration(configuration, CONNECTION_CONFIGURATION);

            PrintTitle("AdoPersonDao.FindAll()");
            DalTester tester2 = new(new AdoPersonDao(factory));
            await tester2.TestFindAllAsync();

            PrintTitle("AdoPersonDao.FindById()");
            await tester2.TestFindByIdAsync();

            PrintTitle("AdoPersonDao.Update()");
            await tester2.TestUpdateAsync();

            PrintTitle("AdoPersonDao.Transactions()");
            await tester2.TestTransactionsAsync();
        }

        private static void PrintTitle(string text = "", int length = 60, char ch = '-')
        {
            int preLen = (length - (text.Length + 2)) / 2;
            int postLen = length - (preLen + text.Length + 2);
            Console.WriteLine($"{new string(ch, preLen)} {text} {new string(ch, postLen)}");
        }

        #endregion
    }
}