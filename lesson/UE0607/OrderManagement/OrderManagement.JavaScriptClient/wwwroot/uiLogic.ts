const btnFetchCustomer: HTMLInputElement = <HTMLInputElement>document.getElementById("btnFetchCustomer");
const txtCustomerId: HTMLInputElement = <HTMLInputElement>document.getElementById("txtCustomerId");
const txtName: HTMLInputElement = <HTMLInputElement>document.getElementById("txtName");
const txtZipCode: HTMLInputElement = <HTMLInputElement>document.getElementById("txtZipCode");
const txtCity: HTMLInputElement = <HTMLInputElement>document.getElementById("txtCity");
const txtRating: HTMLInputElement = <HTMLInputElement>document.getElementById("txtRating")
const errorCustomerId: HTMLInputElement = <HTMLInputElement>document.getElementById("errorCustomerId")

function displayCustomer(customer: Customer) {
    txtName.value = customer.name;
    txtCity.value = customer.city;
    txtZipCode.value = customer.zipCode.toString();
    txtRating.value = customer.rating;
}

function setValidationError(inputElement: HTMLInputElement, errorMessage: string) {
    inputElement.classList.add("is-invalid");
    errorCustomerId.innerHTML = errorMessage;
}

function resetValidationError(inputElement: HTMLInputElement) {
    inputElement.classList.remove("is-invalid");
}

async function onFetchButtonClicked() {
    let customerId = txtCustomerId.value;
    resetValidationError(txtCustomerId);

    try {
        const customer = await fetchCustomerByIdAsync(customerId);
        displayCustomer(customer);
    } catch (ex) {
        setValidationError(txtCustomerId, (<Error>ex)?.message ?? "Unexpected exception");
    }
}


window.onload = () => btnFetchCustomer.onclick = onFetchButtonClicked
