function editContact(contactId) {
    currentContactId = contactId;
    fetch(`http://localhost:5293/api/contact/${contactId}`)
        .then(response => response.json())
        .then(contact => {
            document.getElementById("firstName").value = contact.firstName;
            document.getElementById("lastName").value = contact.lastName;
            document.getElementById("phoneNumber").value = contact.phoneNumber;
            document.getElementById("gender").value = contact.gender;
            document.getElementById("email").value = contact.email;
            document.getElementById("country").value = contact.countryId;
            fetchCitiesForCountry(contact.cityId);
            document.getElementById("birthDate").value = contact.birthDate.split('T')[0];

            $('#addContactModal').modal('show');
        })
        .catch(error => {
            console.error("Error fetching contact details:", error);
        });
}

function saveContact() {
    const newContact = {
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
        phoneNumber: document.getElementById("phoneNumber").value,
        gender: document.getElementById("gender").value === "Male" ? 0 : 1,
        emailAddress: document.getElementById("email").value,
        cityId: parseInt(document.getElementById("city").value),
        birthDate: document.getElementById("birthDate").value
    };

    let requestUrl = 'http://localhost:5293/api/contact/create';
    let method = 'POST';

    console.log(currentContactId);
    if (currentContactId != null) {
        newContact.contactId = currentContactId;
        requestUrl = `http://localhost:5293/api/contact/update`;
        method = 'PATCH';
    }

    console.log(requestUrl);

    fetch(requestUrl, {
        method: method,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newContact)
    })
        .then(response => {
            if (!response.ok) {
                return response.json().then(errorData => {
                    alert((errorData.message || errorData.errors || "Unknown error"));
                    currentContactId = null;
                    throw new Error("Request failed");
                });
            }
        })
        .then(data => {
            const successMessage = currentContactId != null ? "Contact updated successfully." : "Contact created successfully.";
            alert(successMessage);
            $('#addContactModal').modal('hide');
            fetchContacts();
            currentContactId = null;
        })
}

function resetContactForm() {
    document.getElementById("contactForm").reset();
}
$('#addContactModal').on('hidden.bs.modal', function () {
    resetContactForm();
});