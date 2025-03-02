window.addEventListener("load", solve);

function solve() {
    let roomSize = document.getElementById('room-size');
    let timeSlot = document.getElementById('time-slot');
    let fullName = document.getElementById('full-name');
    let email = document.getElementById('email');
    let phoneNumber = document.getElementById('phone-number');

    let previewRoomSize = document.getElementById('preview-room-size');
    let previewTimeSlot = document.getElementById('preview-time-slot');
    let previewFullName = document.getElementById('preview-full-name');
    let previewEmail = document.getElementById('preview-email');
    let previewPhoneNumber = document.getElementById('preview-phone-number');

    let bookRoomButton = document.getElementById('book-btn');
    bookRoomButton.addEventListener('click', bookRoomFunction);

    let previewElement = document.getElementById('preview');

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', editFunction);

    let confirmBookingButton = document.getElementById('confirm-btn');
    confirmBookingButton.addEventListener('click', confirmBookingFunction);

    let confirmationElement = document.getElementById('confirmation');

    let bookAnotherRoomButton = document.getElementById('back-btn');
    bookAnotherRoomButton.addEventListener('click', bookAnotherRoomFunction);

    function bookRoomFunction(event) {
        event.preventDefault();

        if (roomSize.value == '' || Number(roomSize.value) < 1 || timeSlot.value == '' ||
            fullName.value == '' || email.value == '' || phoneNumber.value == '') {
            return;
        }

        previewRoomSize.textContent = roomSize.value;
        previewTimeSlot.textContent = timeSlot.value;
        previewFullName.textContent = fullName.value;
        previewEmail.textContent = email.value;
        previewPhoneNumber.textContent = phoneNumber.value;

        previewElement.style.display = 'block';
        bookRoomButton.disabled = true;

        roomSize.value = '';
        timeSlot.value = '';
        fullName.value = '';
        email.value = '';
        phoneNumber.value = '';
    }

    function editFunction() {
        roomSize.value = previewRoomSize.textContent;
        timeSlot.value = previewTimeSlot.textContent;
        fullName.value = previewFullName.textContent;
        email.value = previewEmail.textContent;
        phoneNumber.value = previewPhoneNumber.textContent;

        previewElement.style.display = 'none';
        bookRoomButton.disabled = false;
    }

    function confirmBookingFunction() {
        previewElement.style.display = 'none';
        confirmationElement.style.display = 'block';
    }

    function bookAnotherRoomFunction() {
        confirmationElement.style.display = 'none';
        bookRoomButton.disabled = false;
    }
}
