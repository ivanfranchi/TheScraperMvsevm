
1) Scraper.Application\Services\Scraper => ScrapeAsync:
The value of the CONSENT might need to be updated with a fresh cookie consent.
It can be copied from the Application tab of the dev tools of the browser after agreeing with Google.

message.Headers.Add("Cookie", "CONSENT=YES+shp.gws-20220120-0-RC1.en+FX+515");


2) VueJScraper\src\components\Home.vue
The port of "baseUrl" needs to match the value of the WebApi app.
(the value can be seen running the app)
The page says: "Welcome Scraper (backend)"


3) WebCoreScraper\Startup.cs => app.UseCors
The port needs to match the value of the SPA.
(the value can be seen running the app)


4) npm install from VueJScraper


5) Change the solution properties to multiple startup
	(Application then WebApi then VueJScraper)
Otherwise start the 2 (WebApi first then VueJScraper) manually. Build dependencies first.

