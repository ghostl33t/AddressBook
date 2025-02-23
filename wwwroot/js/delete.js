function showDeleteModal(contactId, firstName, lastName, phoneNumber) {
    document.getElementById("contactName").innerText = `Name: ${firstName} ${lastName}`;
    document.getElementById("contactPhoneNumber").innerText = `Phone: ${phoneNumber}`;

    contactIdToDelete = contactId;

    document.getElementById("deleteModal").style.display = "block";
}

function closeModal() {
    document.getElementById("deleteModal").style.display = "none";
}

async function confirmDelete() {
    if (contactIdToDelete !== null) {
        await deleteContact(contactIdToDelete);
    }
    closeModal();
}

async function deleteContact(contactId) {
    try {
        const response = await fetch(`http://localhost:5293/api/contact/${contactId}`, {
            method: 'DELETE',
        });

        if (!response.ok) {
            alert('Failed to delete contact.');
            return;
        }

        alert('Contact deleted successfully.');
        fetchContacts();
    } catch (error) {
        console.error("Error deleting contact:", error);
    }
}
