<template>
    <div class="home">
        <h1>{{ msg }}</h1>

        <h3>Insert URL:</h3>
        <input v-model.lazy="searchText" placeholder="www.infotrack.co.uk" @change="inputChanged">
        <p>(defaulting to) www.infotrack.co.uk</p>
        <hr />

        <h3>Insert search phrase:</h3>
        <input v-model.lazy="searchKeywords" placeholder="land registry searches" @change="inputChanged">
        <p>(defaulting to) land registry searches</p>
        <hr />

        <h3>How many results?</h3>
        <input v-model="resultAmount">
        <hr />

        <button @click="scrapeThis">Go Scrape!</button>
        <hr />

        <div v-if="showResults">
            <div v-if="negativeResult()">
                <h3>Sorry, "{{searchText}}" does not appear searching for "{{searchKeywords}}"</h3>
            </div>
            <div v-else>
                <h3>Congratulations! {{searchText}} appeared in position:</h3>
                <div v-for="val in results">
                    <p>{{val}}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Prop, Vue } from 'vue-property-decorator';

    @Component
    export default class Home extends Vue {
        @Prop() private msg!: string;
        baseUrl: string = "https://localhost:44361/"
        reply: string = "";
        searchText: string = "";
        searchKeywords: string = "";
        resultAmount: string = "100";
        showResults: boolean = false;
        results: string[] = [];

        public async scrapeThis(): Promise<void> {
            this.showResults = false;

            if (this.searchText == "") {
                this.searchText = "www.infotrack.co.uk";
            }
            if (this.searchKeywords == "") {
                this.searchKeywords = "land registry searches";
            }
            await this.scrapeTheWeb(this.searchText, this.searchKeywords, this.resultAmount);
        }

        public negativeResult(): boolean {
            if (this.results.length == 1 && this.results[0] == "0") {
                return true;
            } else {
                return false;
            }
        }

        public inputChanged(): void {
            this.showResults = false;
        }

        private async scrapeTheWeb(textToFind: string, keywordsToSearch: string, howMany: string): Promise<void> {
            try {
                const response =
                    await fetch(`${this.baseUrl}ScraperHome/GetScrapeInfo/${textToFind}/${keywordsToSearch}/${howMany}`);

                if (response.ok) {
                    let tmpRes = await response.text();
                    this.results = this.cleanResult(tmpRes);
                    this.showResults = true;
                } else {
                    console.error(await response.text());
                }
            } catch (err) {
                console.error(JSON.stringify(err));
            }
        }

        private cleanResult(tmpRes: string): string[] {
            tmpRes = tmpRes.replace("[", "");
            tmpRes = tmpRes.replace("]", "");
            return tmpRes.split(',');
        }
    }
</script>

<style scoped>
</style>
