fetch('http://localhost:54941/author')
    .then(x => x.json())
    .then(y => console.log(y));