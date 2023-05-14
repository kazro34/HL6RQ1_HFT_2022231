let noncrud01 = [];

async function getdata01() {
    await fetch('http://localhost:54941/Stat/AVGLentingPrice')
        .then(x => x.json())
        .then(y => {
            price = y;
            
        });
    var x = document.getElementById("AVG");
    if (x.innerHTML === "") {
        x.innerHTML = price.toFixed(0);
    }
        };

async function getdata02() {
    await fetch('http://localhost:54941/Stat/StillOpenLentsByBookId')
        .then(x => x.json())
        .then(y => {
            noncrud01 = y;
            var x = document.getElementById("Open");
            x.innerHTML = noncrud01;
        })
};

async function getdata03() {
    await fetch('http://localhost:54941/Stat/HasToPayFine')
        .then(x => x.json())
        .then(y => {
            noncrud01 = y;
            var x = document.getElementById("Latency");
            x.innerHTML = noncrud01;
            })
        };

async function getdata04() {
    await fetch('http://localhost:54941/Stat/AVGLentingPricesByAuthors')
        .then(x => x.json())
        .then(y => {
            noncrud01 = y;
            console.log(noncrud01)
            noncrud01.forEach(t => {
                document.getElementById('resultNONCRUD01').innerHTML +=
                    "<tr><td>" + t.key + "</td><td>"
                    + t.value + "</td></tr>";
            })
        })
}

async function getdata05() {
    let str = document.getElementById('year').value;

    str = "http://localhost:54941/Stat/GetAverageIncomePerBookPerYear/" + str;

    await fetch(str)
        .then(x => x.json())
        .then(y => {
            noncrud01 = y;
            console.log(noncrud01)
            noncrud01.forEach(t => {
                document.getElementById('resultNONCRUD01').innerHTML +=
                    "<tr><td>" + t.key + "</td><td>"
                    + t.value + "</td></tr>";
            })
        })
}