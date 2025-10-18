
window.onload= async ()=>{
   var url = 'https://localhost:7144/api/Cars';

   var request = await fetch(url, 
    {
        method : 'GET',
        headers : {'Content-Type' : 'application/json'}
    });

    var response = await request.json();

    console.log(response);
    ShowText(response)
}

function ShowText(getAllCAr){

    var text='';
    for (item of getAllCAr){
            text += `
               <div class="card bg-primary text-white" style="width:200px; float:left; margin:5px;">
                <div class="card-body">
                    <h4 class="card-title">${item.brand}</h4>
                    <p class="card-text">${item.id}</p>
                    <p class="card-text">${item.type}</p>
                     <p class="card-text">${item.color}</p>
                      <p class="card-text">${item.year.substr(0,4)}</p>
                </div>
                </div>
            `;
    }

   

    return document.getElementById("root").innerHTML = text;
}