async function fetchContacts() {
    try {
        const response = await fetch('http://localhost:5293/api/contact/all');
        const contacts = await response.json();

        const tableBody = document.getElementById("contactTable").getElementsByTagName("tbody")[0];
        tableBody.innerHTML = '';

        contacts.forEach(contact => {
            const row = tableBody.insertRow();
            row.innerHTML = `
                                    <td hidden="hidden">${contact.id}</td>
                                    <td>${contact.firstName}</td>
                                    <td>${contact.lastName}</td>
                                    <td>${contact.phoneNumber}</td>
                                    <td>
                                        <span class="gender-circle"
                                              style="background-color: ${contact.gender === 'Male' ? 'blue' : 'red'};">
                                        </span>
                                    </td>
                                    <td>${contact.email}</td>
                                    <td>${contact.countryName}</td>
                                    <td>${contact.cityName}</td>
                                    <td>${contact.birthDate}</td>
                                    <td>${contact.age}</td>
                                    <td>
                                        <button class="edit-btn" onclick="editContact(${contact.id})">Edit</button>
                                        <button class="delete-btn" onclick="showDeleteModal(${contact.id}, '${contact.firstName}', '${contact.lastName}', '${contact.phoneNumber}')">Delete</button>
                                    </td>
                            `;
        });
    } catch (error) {
        console.error("Error fetching contacts:", error);
    }
}

async function fetchCountries() {
    try {
        const response = await fetch('http://localhost:5293/api/country/all-countries');
        const countries = await response.json();
        const countrySelect = document.getElementById('country');
        countrySelect.innerHTML = '<option value="">Select a Country</option>';

        countries.forEach(country => {
            const option = document.createElement('option');
            option.value = country.countryId;
            option.textContent = country.countryName;
            countrySelect.appendChild(option);
        });
    } catch (error) {
        console.error("Error fetching countries:", error);
    }
}

async function fetchCitiesForCountry(selectedCityId = null) {
    const countryId = document.getElementById('country').value;

    if (!countryId) {
        return;
    }

    try {
        const response = await fetch(`http://localhost:5293/api/city/cities-for-country/${countryId}`);
        const cities = await response.json();
        const citySelect = document.getElementById('city');
        citySelect.innerHTML = '<option value="">Select a City</option>';

        cities.forEach(city => {
            const option = document.createElement('option');
            option.value = city.cityId;
            option.textContent = city.cityName;
            citySelect.appendChild(option);
        });

        if (selectedCityId) {
            document.getElementById("city").value = selectedCityId;
        }

    } catch (error) {
        console.error("Error fetching cities:", error);
    }
}