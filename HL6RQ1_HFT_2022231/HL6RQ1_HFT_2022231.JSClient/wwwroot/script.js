let authors = [];
let connection;

let authorIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:54941/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        getdata();
    });

    connection.on("AuthorDeleted", (user, message) => {
        getdata();
    });

    connection.on("AuthorUpdated", (user, message) => {
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
    await fetch('http://localhost:54941/author/')
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
            "<tr><td>" + t.authorId + "</td><td>" + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.authorId})">Delete</button>`+
            `<button type="button" onclick="showupdate(${t.authorId})">Update</button>`
            + "</td></tr>";
    });
}

function create() {
    let name = document.getElementById('authorname').value;
    fetch('http://localhost:54941/author/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })})
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function showupdate(id) {
    document.getElementById('authornametoupdate').value = authors.find(t => t['authorId'] == id)['name'];
    document.getElementById('updateformdiv').style.display = 'flex';
    authorIdToUpdate = id;
}

function update() {
    let name = document.getElementById('authornametoupdate').value;
    fetch('http://localhost:54941/author', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, authorId: authorIdToUpdate})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function remove(id) {
    fetch('http://localhost:54941/author/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}