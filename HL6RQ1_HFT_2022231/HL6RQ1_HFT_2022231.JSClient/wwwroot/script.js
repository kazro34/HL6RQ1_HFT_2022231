let authors = [];

fetch('http://localhost:54941/author')
    .then(x => x.json())
    .then(y => {
        authors = y;
        console.log(authors);     
        display()
    });

function display() {
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.authorId + "</td><td>" + t.name + "</td></tr>";
    });
}