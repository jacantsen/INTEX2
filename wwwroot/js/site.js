// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#filterBtn").off("click").on("click", function () {
        $("body").toggleClass("sidebar-open-mum");
    });
    $("#hideBtn").off("click").on("click", function () {
        $("body").toggleClass("sidebar-open-mum");
    });

});

document.addEventListener("DOMContentLoaded", function () {
    // Attach click event listeners for the faceBundle switch options
    document.getElementById("option-yes").addEventListener("click", function () {
        toggleSwitch("yes");
    });

    document.getElementById("option-no").addEventListener("click", function () {
        toggleSwitch("no");
    });

    // Attach click event listeners for the gender switch options
    document.getElementById("male").addEventListener("click", function () {
        toggleGender("male");
    });

    document.getElementById("female").addEventListener("click", function () {
        toggleGender("female");
    });


    const deleteForms = document.getElementsByClassName("delete-form");
    for (let i = 0; i < deleteForms.length; i++) {
        deleteForms[i].addEventListener("submit", function (event) {
            if (!confirmDelete()) {
                event.preventDefault();
            }
        });
    }

    function confirmDelete() {
        return confirm('Are you sure you want to delete this record?');
    }

    //delete button  modal event listener
        // Modal-related code
    const deleteModalBtns = document.getElementsByClassName("delete-modal-btn");
    const modal = document.getElementById("id01");
    const closeButton = document.querySelector(".close");
    const cancelButton = document.querySelector(".cancelbtn");

    function showModal() {
        modal.style.display = "block";
    }

    function closeModal() {
        modal.style.display = "none";
    }

    function showDeleteModal(event) {
        event.preventDefault();
        const mummyId = event.target.getAttribute("data-mummy-id");
        document.getElementById("mummy_id").value = mummyId;
        showModal();
    }

    for (let i = 0; i < deleteModalBtns.length; i++) {
        deleteModalBtns[i].addEventListener("click", showDeleteModal);
    }

    closeButton.addEventListener("click", closeModal);
    cancelButton.addEventListener("click", closeModal);

    window.addEventListener("click", function (event) {
        if (event.target === modal) {
            closeModal();
        }
    });



});



function toggleSwitch(option) {
    const optionYes = document.getElementById("option-yes");
    const optionNo = document.getElementById("option-no");
    const toggleValue = document.getElementById("faceBundle");

    if (option === "yes") {
        optionYes.classList.add("active");
        optionNo.classList.remove("active");
        toggleValue.value = "Y";
    } else {
        optionYes.classList.remove("active");
        optionNo.classList.add("active");
        toggleValue.value = "N";
    }
}


function toggleGender(option) {
    const optionMale = document.getElementById("male");
    const optionFemale = document.getElementById("female");
    const toggleValue = document.getElementById("sex");

    if (option === "male") {
        optionMale.classList.add("active");
        optionFemale.classList.remove("active");
        toggleValue.value = "M";
    } else {
        optionMale.classList.remove("active");
        optionFemale.classList.add("active");
        toggleValue.value = "F";
    }
}

