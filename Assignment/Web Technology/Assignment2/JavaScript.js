// 1.Area of a triangle using Heron's formula
//Sides of the triangle
let a = 5;
let b = 6;
let c = 7;

// Semi-perimeter
let s = (a + b + c) / 2;

// Area 
let area = Math.sqrt(s * (s - a) * (s - b) * (s - c));

console.log("Area of the triangle is:", area);



//2. to print pattern
let rows = 5;

for (let i = 1; i <= rows; i++) {
    let pattern = "";
    for (let j = 1; j <= i; j++) {
        pattern += "* ";
    }
    console.log(pattern);
}

//3. to check leap year
let year1 = 2024;

if ((year1 % 4 === 0 && year1 % 100 !== 0) || (year1 % 400 === 0)) {
    console.log(year1 + " is a Leap Year");
} else {
    console.log(year1 + " is NOT a Leap Year");
}


//4. Write a JavaScript program that calculates the number of days left until Independence Day by comparing the current date with August 15th of the current year. If today is after August 15th, it calculates the days until next year's Independence Day. The difference in days is then logged to the console.
let today = new Date();
let year = today.getFullYear();
let independenceDay = new Date(year, 7, 15); 

// If today is after August 15, calculate for next year
if (today > independenceDay) {
    independenceDay = new Date(year + 1, 7, 15);
}

// Calculate difference in milliseconds
let diffTime = independenceDay - today;

// Convert milliseconds to days
let diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));

console.log("Days left until Independence Day:", diffDays);