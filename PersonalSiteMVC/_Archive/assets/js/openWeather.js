// Info gathered from https://openweathermap.org

returnWeather = () => {
    let userZip = document.getElementById('userZip').value

    console.log(userZip)

    $.ajax({
        url: `https://api.openweathermap.org/data/2.5/weather?zip=${userZip},us&units=imperial&appid=12a1ac4ef19c6442c97bd5ad7ae57758`,

        method: 'GET',

        success: function (x) {
            console.log(x)
            console.table(x)

            // Store results in var
            var weather = x

            // Capture output element
            var weatherResults = document.getElementById('weatherResults')

            var sunrise = new Date(x.sys.sunrise * 1000)
            var sunset = new Date(x.sys.sunset * 1000)

            // insert data into empty div
            weatherResults.innerHTML = `<div class="col-lg-12 p-3">
                        <div class="text-center">
                            <h3> Weather = ${x.name}</h3>
                            <p>${x.weather.map(x => x.description)}</p>
                            <p>Feels Like: ${x.main.feels_like}&deg;F</p>
                            <p>Current Temp: ${x.main.temp}&deg;F</p>
                            <p>Low: ${x.main.temp_min}&deg;F</p>
                            <p>High: ${x.main.temp_max}&deg;F</p>
                            <p>Sunrise: ${sunrise}</p>
                            <p>Sunset: ${sunrise}</p>

                        </div>
                    </div>`
        },
    })
}
