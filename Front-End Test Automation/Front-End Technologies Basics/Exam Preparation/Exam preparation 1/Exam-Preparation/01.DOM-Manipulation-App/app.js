window.addEventListener("load", solve);

function solve() {
    let numberOfTickets = document.getElementById('num-tickets');
    let seatingPreference = document.getElementById('seating-preference');
    let fullName = document.getElementById('full-name');
    let email = document.getElementById('email');
    let phoneNumber = document.getElementById('phone-number');

    let purchaseNumberOfTickets = document.getElementById('purchase-num-tickets');
    let purchaseSeatingPreference = document.getElementById('purchase-seating-preference');
    let purchaseFullName = document.getElementById('purchase-full-name');
    let purchaseEmail = document.getElementById('purchase-email');
    let purchasePhoneNumber = document.getElementById('purchase-phone-number');

    let purchaseTicketsButton = document.getElementById('purchase-btn');
    purchaseTicketsButton.addEventListener('click', purchaseTicketsFunction);

    let ticketPreviewElement = document.getElementById('ticket-preview');

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', editFunction);

    let buyButton = document.getElementById('buy-btn');
    buyButton.addEventListener('click', buyFunction);

    let purchaseSuccessElement = document.getElementById('purchase-success');

    let backButton = document.getElementById('back-btn');
    backButton.addEventListener('click', backFunction);

    function purchaseTicketsFunction(event) {
        event.preventDefault();

        if (numberOfTickets.value == '' || Number(numberOfTickets.value) <= 0 || seatingPreference.value == 'seating-preference' || fullName.value == '' || email.value == '' || phoneNumber == '') {
            return;
        }

        purchaseNumberOfTickets.textContent = numberOfTickets.value;
        purchaseSeatingPreference.textContent = seatingPreference.value;
        purchaseFullName.textContent = fullName.value;
        purchaseEmail.textContent = email.value;
        purchasePhoneNumber.textContent = phoneNumber.value;

        ticketPreviewElement.style.display = 'block';
        purchaseTicketsButton.disabled = true;

        numberOfTickets.value = '';
        seatingPreference.value = 'seating-preference';
        fullName.value = '';
        email.value = '';
        phoneNumber.value = '';
    }

    function editFunction() {
        numberOfTickets.value = purchaseNumberOfTickets.textContent;
        seatingPreference.value = purchaseSeatingPreference.textContent;
        fullName.value = purchaseFullName.textContent;
        email.value = purchaseEmail.textContent;
        phoneNumber.value = purchasePhoneNumber.textContent;

        ticketPreviewElement.style.display = 'none';
        purchaseTicketsButton.disabled = false;
    }

    function buyFunction() {
        ticketPreviewElement.style.display = 'none';
        purchaseSuccessElement.style.display = 'block';
    }

    function backFunction() {
        purchaseSuccessElement.style.display = 'none';
        purchaseTicketsButton.disabled = false;
    }
}