function attachEvents() {
    let getWeatherBtn = document.getElementById('submit');
    let locationInput = document.getElementById('location');

    const baseURL = 'https://judgetests.firebaseio.com/';

    getWeatherBtn.addEventListener('click', onGetWeatherClick);

    function onGetWeatherClick() {
        let currentDivInfo = document.querySelector('.forecasts');
        let upcomingDivInfo = document.querySelector('.forecast-info');

        if (currentDivInfo && upcomingDivInfo) {
            currentDivInfo.remove();
            upcomingDivInfo.remove();
        }

        fetch(baseURL + 'locations.json')
            .then(response => response.json())
            .then(locations => {
                let location = locations.find(x => x.name == locationInput.value);

                let currentConditions =
                    fetch(baseURL + `forecast/today/${location.code}.json`)
                        .then(response => response.json());

                let upcomingConditions =
                    fetch(baseURL + `forecast/upcoming/${location.code}.json`)
                        .then(response => response.json());

                let forecastDivElement = document.getElementById('forecast');

                Promise.all([currentConditions, upcomingConditions])
                    .then(([currentInfo, upcomingInfo]) => {
                        forecastDivElement.style.display = 'block';

                        let symbols = {
                            Sunny: '&#x2600',
                            'Partly sunny': '&#x26C5',
                            Overcast: '&#x2601',
                            Rain: '&#x2614',
                            Degrees: '&#176',
                        }

                        let currentDivElement = document.getElementById('current');

                        let currentLocationName = currentInfo.name;
                        let currentForecast = currentInfo.forecast;

                        let currentSymbol = symbols[currentForecast.condition];
                        let currentDegrees = `${currentForecast.low}${symbols.Degrees}/${currentForecast.high}${symbols.Degrees}`;
                        let currentCondition = currentForecast.condition;

                        let currentForecastDiv = createElement('div', 'forecasts', '');
                        let currentForecastSpan1 = createElement('span', 'condition symbol', currentSymbol);
                        let currentForecastSpan2 = createElement('span', 'condition', '');

                        let currentForecastSpanChild1 = createElement('span', 'forecast-data', currentLocationName);
                        let currentForecastSpanChild2 = createElement('span', 'forecast-data', currentDegrees);
                        let currentForecastSpanChild3 = createElement('span', 'forecast-data', currentCondition);

                        currentForecastSpan2.append(currentForecastSpanChild1, currentForecastSpanChild2, currentForecastSpanChild3);
                        currentForecastDiv.append(currentForecastSpan1, currentForecastSpan2);

                        currentDivElement.appendChild(currentForecastDiv);

                        let upcomingDivElement = document.getElementById('upcoming');

                        let upcomingForecasts = upcomingInfo.forecast;

                        let upcomingForecastsDiv = createElement('div', 'forecast-info', '');

                        upcomingForecasts.forEach(forecast => {
                            let forecastSymbol = symbols[forecast.condition];
                            let forecastDegrees = `${forecast.low}${symbols.Degrees}/${forecast.high}${symbols.Degrees}`;
                            let forecastCondition = forecast.condition;

                            let upcomingForecastsSpan = createElement('span', 'upcoming', '');

                            let upcomingForecastsSpanChild1 = createElement('span', 'symbol', forecastSymbol);
                            let upcomingForecastsSpanChild2 = createElement('span', 'forecast-data', forecastDegrees);
                            let upcomingForecastsSpanChild3 = createElement('span', 'forecast-data', forecastCondition);

                            upcomingForecastsSpan.append(upcomingForecastsSpanChild1, upcomingForecastsSpanChild2, upcomingForecastsSpanChild3);
                            upcomingForecastsDiv.appendChild(upcomingForecastsSpan);
                        });

                        upcomingDivElement.appendChild(upcomingForecastsDiv);

                    })
                    .catch(() => {
                        forecastDivElement.style.display = 'block';
                        forecastDivElement.textContent = 'Error';
                    })
            })

    }

    function createElement(type, className, text) {
        let element = document.createElement(type);

        element.className = className;
        element.innerHTML = text;

        return element;
    }
}

attachEvents();