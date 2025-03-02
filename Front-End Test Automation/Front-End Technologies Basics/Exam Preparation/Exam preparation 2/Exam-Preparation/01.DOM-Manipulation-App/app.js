window.addEventListener('load', solve);

function solve() {
    let carModel = document.getElementById('car-model');
    let carYear = document.getElementById('car-year');
    let partName = document.getElementById('part-name');
    let partNumber = document.getElementById('part-number');
    let condition = document.getElementById('condition');

    let infoCarModel = document.getElementById('info-car-model');
    let infoCarYear = document.getElementById('info-car-year');
    let infoPartName = document.getElementById('info-part-name');
    let infoPartNumber = document.getElementById('info-part-number');
    let infoCondition = document.getElementById('info-condition');

    let nextButton = document.getElementById('next-btn');
    nextButton.addEventListener('click', partInfoFunction);

    let partInfoElement = document.getElementById('part-info');

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', editFunction);

    let confirmButton = document.getElementById('confirm-btn');
    confirmButton.addEventListener('click', confirmFunction);

    let confirmOrderElement = document.getElementById('confirm-order');

    let newOrderButton = document.getElementById('new-btn');
    newOrderButton.addEventListener('click', newOrderFunction);


    function partInfoFunction(event) {
        event.preventDefault();

        if (carModel.value == '' || carYear.value == '' || Number(carYear.value) < 1990 || Number(carYear.value) > 2025 || partName.value == '' || Number(partNumber.value) <= 0 || partNumber.value == '' || condition.value == '') {
            return;
        }

        infoCarModel.textContent = carModel.value;
        infoCarYear.textContent = carYear.value;
        infoPartName.textContent = partName.value;
        infoPartNumber.textContent = partNumber.value;
        infoCondition.textContent = condition.value;

        partInfoElement.style.display = 'block';
        nextButton.disabled = true;
         
        carModel.value = '';
        carYear.value = '';
        partName.value = '';
        partNumber.value = '';
        condition.value = '';
    }

    function editFunction() {
        carModel.value = infoCarModel.textContent;
        carYear.value = infoCarYear.textContent;
        partName.value = infoPartName.textContent;
        partNumber.value = infoPartNumber.textContent;
        condition.value = infoCondition.textContent;

        partInfoElement.style.display = 'none';
        nextButton.disabled = false;
    }

    function confirmFunction() {
        partInfoElement.style.display = 'none';
        confirmOrderElement.style.display = 'block';
    }

    function newOrderFunction() {
        confirmOrderElement.style.display = 'none';
        nextButton.disabled = false;
    }
};
