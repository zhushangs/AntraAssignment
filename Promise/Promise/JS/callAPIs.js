function getComments() {
    fetch("https://jsonplaceholder.typicode.com/comments").then(function (response) {
        return response.json();
    }).then(function (data) {
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = ""
        let length = data.length;
        for (let i = 0; i < length; i++) {
            let tr = "<tr> <td>" + data[i].id + "</td> <td>" + data[i].name + "</td> <td>" + data[i].email + "</td> <td>" + data[i].body + "</td> </tr>"
            tbody.innerHTML += tr;
        }
    }).catch(function (e) {
        console.log(e)
    })
}

function getTodos() {
    fetch("https://jsonplaceholder.typicode.com/todos").then(function (response) {
        return response.json();
    }).then(function (data) {
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = ""
        let length = data.length;
        for (let i = 0; i < length; i++) {
            let tr = "<tr> <td>" + data[i].id + "</td> <td>" + data[i].title + "</td> <td>" + data[i].completed + "</td> </tr>"
            tbody.innerHTML += tr;
        }
    }).catch(function (e) {
        console.log(e)
    })
}

function getPosts() {
    fetch("https://jsonplaceholder.typicode.com/posts").then(function (response) {
        return response.json();
    }).then(function (data) {
        let tbody = document.querySelector("tbody");
        tbody.innerHTML = ""
        let length = data.length;
        for (let i = 0; i < length; i++) {
            let tr = "<tr> <td>" + data[i].id + "</td> <td>" + data[i].title + "</td> <td>" + data[i].body + "</td> </tr>"
            tbody.innerHTML += tr;
        }
    }).catch(function (e) {
        console.log(e)
    })
}
