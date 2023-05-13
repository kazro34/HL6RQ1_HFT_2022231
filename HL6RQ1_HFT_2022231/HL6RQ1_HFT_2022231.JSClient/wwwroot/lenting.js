let lentings = [];
let connection = null;

let lentingIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:54941/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("LentingCreated", (user, message) => {
        getdata();
    });

    connection.on("LentingDeleted", (user, message) => {
        getdata();
    });

    connection.on("LentingUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        awaitconnection.start();
        console.log("SignalRConnected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:54941/lenting/')
        .then(x => x.json())
        .then(y => {
            authors = y;
            //console.log(authors);
            display()
        });
}



function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.Id + "</td><td>" + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.Id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.Id})">Update</button>`
            + "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('lentingname').value;
    fetch('http://localhost:54941/lenting/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('lentingnametoupdate').value = lentings.find(t => t['Id'] == id)['Name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    lentingIdToUpdate = id;
}

function update() {
    let name = document.getElementById('lentingnametoupdate').value;
    fetch('http://localhost:54941/lenting', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Id: lentingIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:54941/lenting/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}