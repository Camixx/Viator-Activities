const searchContainer = document.querySelector('.search-input-box');
const inputSearch = searchContainer.querySelector('input');
const boxSuggestions = document.querySelector(
	'.container-suggestions'
);

const searchLink = document.querySelector('a');

inputSearch.onkeyup = async (e) => {
	let userData = e.target.value;

	if (userData) {
		let destinations = await getDestinationsFromApi(userData);

		destinations = destinations.map(data => {
			return (data = `<li>${data}</li>`);
		});
		searchContainer.classList.add('active');
		showSuggestions(destinations);

		let allList = boxSuggestions.querySelectorAll('li');

		allList.forEach(li => {
			li.setAttribute('onclick', 'select(this)');
		});
	} else {
		searchContainer.classList.remove('active');
	}
};

function select(element) {
	let selectUserData = element.textContent;
	inputSearch.value = selectUserData;

	searchLink.href = `https://www.google.com/search?q=${inputSearch.value}`;
	searchContainer.classList.remove('active');
}

const showSuggestions = list => {
	let listData;

	if (!list.length) {
		userValue = inputSearch.value;
		listData = `<li>${userValue}</li>`;
	} else {
		listData = list.join(' ');
	}
	boxSuggestions.innerHTML = listData;
};

async function getDestinationsFromApi(userData) {
	const response = await fetch("/destinations?name=" + userData);
	destinations = await response.json();
	return destinations;
}
