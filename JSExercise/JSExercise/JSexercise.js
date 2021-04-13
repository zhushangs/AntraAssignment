
let salaries = {
    John: 100,
    Ann: 160,
    Pete: 130
}

var sum = salaries.John + salaries.Ann + salaries.Pete;
console.log(sum);


let menu = {
    width: 200,
    height: 300,
    title: "My menu"
};

multiplyNumeric(menu);

// after the call
menu = {
    width: 400,
    height: 600,
    title: "My menu"
};

function multiplyNumeric(obj) {
    for (let numeric in obj) {
        if (typeof obj[numeric] == 'number') {
            obj[numeric] *= 2;
        }
    }
    /*return obj;*/
}

/*console.log(menu)*/
var str = "julia@gmail.com";

function checkEmailId(str) {
    const reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return reg.test(String(str).toLowerCase());
}

console.log(checkEmailId(str));


function truncate(str, maxlength) {
    if (str.length > maxlength) {
        return str.substring(0, maxlength - 1) + "...";
    }
    return str;
}

console.log(truncate("Hi everyone!", 20))

var items = ["James", "Brennie"];
console.log(items)
items.push("Robert")
console.log(items)
items.splice(items.length / 2, 1, "Calvin");
console.log(items)
items.shift()
console.log(items)
items.unshift("Rose", "Regal")
console.log(items)

var card = "6724843711060148";
card.split('')
var bannedPrefix = ["11", "3434", "67453", "9"]
var pre = card[card.length - 1];
/*var pre = parseFloat(card[card.length-1]);*/

console.log(card)
console.log(pre)

function validateCards(cardNumber, prefix) {
    isValid = false;
    isAllowed = false;
    var str = cardNumber.substring(0, cardNumber.length - 1).split('');
    console.log(str);

    var arr = str.map(function (x) {
        return parseInt(x, 10);
    });
    console.log(arr)

    var afterDouble = arr.map(function (x) { return x * 2; });
    console.log(afterDouble)

    var sum = afterDouble.reduce((a, b) => a + b)
    console.log(sum)

    var reminder = sum % 10;
    console.log(reminder)

    var valid = parseInt(card[card.length - 1]);
    console.log(pre)

    if (reminder == valid) {
        isValid = true;
    }
    console.log(isValid)

    if (!prefix.includes(reminder)) {
        isAllowed = true;
    }
    console.log(isAllowed)

    var obj = {
        "card:": cardNumber,
        "isValid:": isValid,
        "isAllowed": isAllowed
    }

    return JSON.stringify(obj)
  
}

console.log(validateCards(card, bannedPrefix))


function validEmail(str) {
    var emailPattern = /^[a-z]{1,6}_?\d{0,4}@hackerrank+\.[a-z]{2,}$/;
    return emailPattern.test(str); 
}

var emails = ["julia@hackerrank.com", "julia_@hackerrank.com", "julia_0@hackerrank.com", "julia0_@hackerrank.com","julia@gmail.com"]

console.log(emails.map(x => validEmail(x)))

