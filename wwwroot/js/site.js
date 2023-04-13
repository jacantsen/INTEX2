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

function toggleSwitch(option) {
    const optionYes = document.getElementById("option-yes");
    const optionNo = document.getElementById("option-no");
    const toggleValue = document.getElementById("faceBundle");

    if (option === "yes") {
        optionYes.classList.add("active");
        optionNo.classList.remove("active");
        toggleValue.value = "yes";
    } else {
        optionYes.classList.remove("active");
        optionNo.classList.add("active");
        toggleValue.value = "no";
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


    function confirmDelete() {
        return confirm('Are you sure you want to delete this record?');
    }






    $(document).ready(function () {
        $("body").on("click", ".details-link", function (event) {
            event.preventDefault();
            let url = $(this).attr("href");
            $("#mummyModal .modal-body").load(url, function (response, status, xhr) {
                if (status == "error") {
                    console.error("Error loading partial view:", xhr.status, xhr.statusText);
                } else {
                    $("#mummyModal").modal("show");
                }
            });
        });
    });


    $(document).ready(function () {
        $("body").on("click", ".details-link", function (event) {
            event.preventDefault();
            let url = $(this).attr("href");
            $("#mummyModal .modal-body").load(url, function () {
                $("#mummyModal").modal("show");
            });
        });
        });


