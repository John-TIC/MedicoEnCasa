let latitud = 0;
let longitud = 0;
let heightShow = 5;

// Funciona pra capturar las coordenadas actuales
function InitLocations() {
  if (!navigator.geolocation) {
    return alert("Tu navegador no soporta el acceso a la ubicacion");
  }

  function onPosition(ubication) {
    console.log("Ubication is: ", ubication);
    latitud = ubication.coords.latitude;
    longitud = ubication.coords.longitude;
    heightShow = 12;
  }

  function onPositionError(error) {
    console.log("Ubication error is: ", error);
  }

  const optionsPositions = {
    enableHighAccuracy: true, // Alta precision
    maximunAge: 0, // No cache
    timeout: 5000, // Espera 5 segundos
  };

  navigator.geolocation.getCurrentPosition(
    onPosition,
    onPositionError,
    optionsPositions
  );

  return new Promise((resolve, reject) => {
    setTimeout(() => {
        resolve();
    }, 2000)
  });
}

//Carga mapa cuando carga el DOM
document.addEventListener("DOMContentLoaded", async (e) => {
  await InitLocations();

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