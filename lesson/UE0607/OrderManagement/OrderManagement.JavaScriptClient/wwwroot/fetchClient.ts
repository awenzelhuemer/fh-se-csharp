const ORDER_MANAGEMENT_BASE_URI = "http://localhost:8000";

interface Customer {
    id: string;
    name: string;
    zipCode: number;
    city: string;
    rating: string;
}

async function fetchCustomerByIdAsync(customerId: string): Promise<Customer> {
    if (!customerId) {
        throw new Error(`Invalid customer id ${customerId}`);
    }

    const response = await fetch(`${ORDER_MANAGEMENT_BASE_URI}/api/customers/${customerId}`, {
        method: 'GET', // Default value
        headers: { "Accept": "application/json" }
    });

    if (response.status !== 200) {
        throw new Error(`failed with status code ${response.status}`);
    }

    return await response.json();
}