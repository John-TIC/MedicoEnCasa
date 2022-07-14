var mymap = L.map('mimapa').setView([6.2063, -75.5951], 12);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 19,
    attribution: '© OpenStreetMap'
}).addTo(mymap);

var myIcon1 = L.icon({
    iconUrl: '~/../icon/heart-beat.png',
    iconSize: [38, 38],
    iconAnchor: [38, 38],
    popupAnchor: [-10, -38],
});

let pacientes = [
    {
        nombres: "Rodolfo Hernandez",
        diagnostico: "Cancer",
        latitud: 6.2063,
        longitud: -75.5951

    },
    {
        nombres: "Federico Gutierrez",
        diagnostico: "Gripe",
        latitud: 6.2002,
        longitud: -75.5751
    },
    {
        nombres: "Gustavo Petro",
        diagnostico: "Covid 19",
        latitud: 6.212,
        longitud: -75.5451
    },
    {
        nombres: "Gutavo Bolivar",
        diagnostico: "Sida",
        latitud: 6.2112,
        longitud: -75.5025
    },
]

var popup = L.popup();
pacientes.forEach(p => {
    let marker = L.marker([p.latitud, p.longitud], { icon: myIcon1 })
        .addTo(mymap)
        .bindPopup(`<b>${p.nombres}</b><br>${p.diagnostico}`);
});

function onMapClick(e) {
    popup
        .setLatLng(e.latlng)
        .setContent("You clicked the map at " + e.latlng.toString())
        .openOn(mymap);
}

function onPupupEvent(e) {
    //            console.log(e);
    console.log(e.popup._leaflet_id)
}

//        mymap.on('click', onMapClick);
mymap.on('popupopen', onPupupEvent);


