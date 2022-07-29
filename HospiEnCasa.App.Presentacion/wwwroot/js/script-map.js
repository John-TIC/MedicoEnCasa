let latitud = 0;
let longitud = 0;
let heightShow = 5;

// Funciona pra capturar las coordenadas actuales
function InitLocations() {

  return new Promise((resolve, reject) => {
    if (!navigator.geolocation) {
      alert("Tu navegador no soporta el acceso a la ubicacion");
      resolve(true);
    }

    function onPosition(ubication) {
      console.log("Ubication is: ", ubication);
      latitud = ubication.coords.latitude;
      longitud = ubication.coords.longitude;
      heightShow = 10;
      resolve(true);
    }

    function onPositionError(error) {
//      console.log("Ubication error is: ", error);
      reject(error);
    }

    const optionsPositions = {
      enableHighAccuracy: false, // baja precision
      maximunAge: 0, // No cache
      timeout: 10000, // Espera 5 segundos
    };

    navigator.geolocation.getCurrentPosition(
      onPosition,
      onPositionError,
      optionsPositions
    );
  })
}

//Carga mapa cuando carga el DOM
document.addEventListener("DOMContentLoaded", async (e) => {

  try {
    await InitLocations();
  } catch (error) {
    console.error("Error geolocalizacion: ", error);
  }


  let mymap = L.map("mimapa").setView([latitud, longitud], heightShow);

  L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png", {
    maxZoom: 19,
    attribution: "© OpenStreetMap",
  }).addTo(mymap);

  var myIcon1 = L.icon({
    iconUrl: "../icon/heart-beat.png",
    iconSize: [38, 38],
    iconAnchor: [38, 38],
    popupAnchor: [-10, -38],
  });

  $(function(){
    $.get("/LocationsPacientes/").done(function (locationsPacientes){

      console.log(locationsPacientes);
      locationsPacientes.forEach((lp) => {
        let marker = L.marker([lp.latitud, lp.longitud], { icon: myIcon1 })
          .addTo(mymap)
          .bindPopup(
            `<b>${lp.fullName}</b><br>${lp.diagnostico}<br><a href="/Pacientes/Paciente/${lp.idPaciente}">Ver paciente</a>`
          );
      });
    })
  });
})