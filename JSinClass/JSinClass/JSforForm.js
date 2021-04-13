function showInput() {
    document.getElementById('display').innerHTML =
        document.getElementById("user_input").value;
}

function showMessage() {
    var message = document.getElementById("message").value;
    display_message.innerHTML = message;
}

function showSummary() {
    document.getElementById("summary").innerHTML = "Summary";
    document.getElementById("displayName").innerHTML = "Name: " + document.getElementById("name").value;
    document.getElementById("displayMobile").innerHTML = "Mobile: " + document.getElementById("mobile").value;
    document.getElementById("displayEmail").innerHTML = "Email: " + document.getElementById("email").value;
    document.getElementById("displayCars").innerHTML = "Cars: " + document.getElementById("cars").value;
    document.getElementById("displayYears").innerHTML = "Years: " + document.getElementById("year").value;
    document.getElementById("displayPrice").innerHTML = "Price: " + document.getElementById("price").value;
}

function getPrice() {
    var car = document.getElementById("cars").value;
    var year = document.getElementById("year").value;
    var price = 0;

    if (car == "Toyota" && year == 2021) {
        price = 1000;
    } else if (car == "Toyota" && year == 2020) {
        price = 800;
    } else if (car == "Honda" && year == 2021) {
        price = 990;
    } else if (car == "Honda" && year == 2020) {
        price = 810;
    }

    document.getElementById("price").value = price;

}