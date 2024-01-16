const searchContainer = document.querySelector('.search-input-box');
const inputSearch = searchContainer.querySelector('input');
const boxSuggestions = document.querySelector(
	'.container-suggestions'
);

const searchLink = document.querySelector('a');


// En base a las letras que se van tipeando (evento), se captura el contenido del inputSearch y muestran sugerencias (nombres de paises) en el dropdown.
inputSearch.onkeyup = async (e) => {
	// Contenido del input search
	let userData = e.target.value;

	if (userData) {
		destinations = await getDestinationsFromApi(userData);

		destinations = destinations.map(data => {
			return (data = `<li value=${data.DestinationId} >${data.DestinationName}</li>`);
		});

		searchContainer.classList.add('active');
		showSuggestions(destinations);

		let allList = boxSuggestions.querySelectorAll('li');

		// por cada elemento <li> le agrega un evento onclick, al cual le asigna la funcion select()
		allList.forEach(li => {
			li.setAttribute('onclick', 'select(this)');
		});
	} else {
		searchContainer.classList.remove('active');
	}
};

// Recibe un <li>, del cual toma los atributos value (destinationId) y textContent (destinationName)
// actualiza el href con un path que lleva a las actividades del destinationId seleccionado
// para terminar ocultando las demas sugerencias
function select(element) {
	let destinationId = element.value;
	// asigna el nombre del destination a la casilla de busqueda donde el usuario esta tipeando
	inputSearch.value = element.textContent;
	// actualiza el href que se encuentra dentro de (<a>)
	searchLink.href = `/activities?destinationId=${destinationId}`;
	// oculta las demas sugerencias
	searchContainer.classList.remove('active');
}

// Dada una lista de <li></li>, las inserta en el dropdown de sugerencias.
// En caso de que la lista esté vacia, inserta en el dropdown de sugerencias unicamente lo que ingresó el usuario por teclado
const showSuggestions = list => {
	let listData;

	// Si la lista es vacia
	if (!list.length) {
		userValue = inputSearch.value;
		listData = `<li>${userValue}</li>`;
	} else {
	// Si la lista no es vacia
		listData = list.join(' ');
	}
	boxSuggestions.innerHTML = listData;
};

async function getDestinationsFromApi(userData) {
	const response = await fetch("/destinations?name=" + userData);
	destinations = await response.json();

	destinations = destinations.map(data => {
		return {
			DestinationId: data.Item1,
			DestinationName: data.Item2
		};
	});

	return destinations;
}

async function createCards(element) {
	const response = await fetch(element);
	activities = await response.json();

	const destinosContainer = document.getElementById('destinosContainer');

	// Limpiar el contenedor antes de agregar nuevas cards
	destinosContainer.innerHTML = '';

	activities.forEach(activity => {
		destinosContainer.innerHTML += createCard(activity);
	});
}

function createCard(activity) {
	return `
      <a href="${activity.productUrl}" class="custom-card col-sm-3 mt-3 no-underline" target="_blank">
        <div class="card custom-card">
		<div class="card-container">
          <img class="card-img-top" src="${activity.image}" alt="Card image cap">
          <div class="card-body">
            <h5 class="card-title">${activity.title}</h5>
            <br>
            <div class="d-flex justify-content-between">
              <p class="card-text text-left">USD${activity.pricing}</p>
              <p class="card-text text-right">★★★★★</p>
            </div>
          </div>
        </div>
		</div>
      </a>
    `;
}

