function handelOnLoad(){
        const allSongsApiUrl = "https://localhost:5001/api/song";
    fetch(allSongsApiUrl).then(function(response)
    {
        console.log(response);
        return response.json();
    }).then(function(json)
    {
        let html = "<ul>";
        json.forEach((song)=>{
            // html += "<li>" + song.songID + " Title: " + song.songTitle + "</li>"
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">` + "SongID: " + song.songID + " " + '<br></br>' + song.songTitle +`</h5>`;
            html += `</div>`;
            html += `</div>`;
        });
        // html += "/<ul";
        document.getElementById("songs").innerHTML = html;
    }).catch(function(error){
        console.log(error);
    })
    var url = "https://localhost:5001/api/song";
    // var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    // let searchString = document.getElementById("searchSong").value;

    // url += searchString;

    // console.log(searchString)
    
    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.songTitle)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}
//     const allSongsApiUrl = "https://localhost:5001/api/song";
//     fetch(allSongsApiUrl).then(function(response)
//     {
//         console.log(response);
//         return response.json();
//     }).then(function(json)
//     {
//         let html = "<ul>";
//         json.forEach((song)=>{
//             html += "<li>" + song.title + " Written by " + song.author + "</li>"
//         });
//         html += "/<ul";
//         document.getElementById("songs").innerHTML = html;
//     }).catch(function(error){
//         console.log(error);
//     })
    // var url = "https://localhost:5001/api/song";
    // var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    // let searchString = document.getElementById("searchSong").value;

    // url += searchString;

    // console.log(searchString)

    // fetch(url).then(function(response) {
	// 	console.log(response);
	// 	return response.json();
	// }).then(function(json) {
    //     console.log(json)
    //     let html = ``;
	// 	json.forEach((song) => {
    //         console.log(song.title)
    //         html += `<div class="card col-md-4 bg-dark text-white">`;
	// 		html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
	// 		html += `<div class="card-img-overlay">`;
	// 		html += `<h5 class="card-title">`+song.title+`</h5>`;
    //         html += `</div>`;
    //         html += `</div>`;
	// 	});
		
    //     if(html === ``){
    //         html = "No Songs found :("
    //     }
	// 	document.getElementById("searchSongs").innerHTML = html;

	// }).catch(function(error) {
	// 	console.log(error);
	// })
// }

var songs = [];
setGreats = function(){
    // var html = "<ul>";
    songs.forEach((song)=>{
        html += "<li><div class=\"avatar\"></div><spann>" + song.songTitle + "</spann></li>";
    })
    // html += "</ul>";
    document.getElementById("songs").innerHTML = html;
    // handelOnLoad();
}


addPost = function(){
    // const postSongApiUrl = "https://localhost:5001/api/song";
    // sendSong ={
        // songID : document.getElementById("songID").value,
        // songTitle : document.getElementById("songTitle").value,
        // songDateTime : document.getElementById("songTimestamp").value,
        // songDelete : dotnet.getElementById("Delete").value,
        // songFavorite : document.getElementById("Favorite").value,
    let postText = document.getElementById("post").value;
    songs.push(postText);
    addSongs(postText);
    // handelOnLoad();
    setGreats();
}
// }

function addSongs(title)
{
    const postSongApiUrl = "https://localhost:5001/api/song";
    sendSong ={
        SongTitle : title,
        songDateTime : "",
        songDelete : "false",
        songFavorite : "",
    }
    
    fetch(postSongApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        console.log(response);
    })
}
function favoriteSongs(title)
{
    var Id = document.getElementById("Favorite").value;
    const favSongApiUrl = "https://localhost:5001/api/song";
    console.log(Id);
    // sendSong ={
    //     // songID : document.getElementById("songID").value,
    //     // SongTitle : title,
    //     // songDateTime : "",
    //     // songDelete : "",
    //     songFavorite : "true",
    // }
    
    fetch(favSongApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify({
            songID : Id,
            SongTitle : title,
            SongTimestamp : new Date().toISOString(),
            Favorite : "true",
        })
    })
    .then((response)=>{
        console.log(response);
        // let postText = document.getElementById("post").value;
        // songs.push(postText);
        // setGreats();
    })
    // const favSongApiUrl = "https://localhost:5001/api/songs";


}
function deleteSongs()
{
    var Id = document.getElementById("Delete").value
    const putSongApiUrl = "https://localhost:5001/api/song/"  +Id;
    
    fetch(putSongApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
    })
    .then((response)=>{
        console.log(response);
        handelOnLoad();
    })
}
