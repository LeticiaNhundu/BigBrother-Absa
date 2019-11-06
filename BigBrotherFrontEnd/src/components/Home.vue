<template>
  <div>
    <md-card md-with-hover>
      <md-card-header>
        <div class="md-layout-item">
          <md-field>
            <md-select v-model="selectedTeam" placeholder="Select Team">
              <md-option
                v-for="teams in teamOptions"
                :key="teams.team_id"
                :value="teams.team_id"
              >{{teams.team_name}}</md-option>
            </md-select>
          </md-field>
        </div>
      </md-card-header>
      <md-divider></md-divider>
      <md-card-content>
        <md-table
          v-model="searched"
          md-sort="name"
          md-sort-order="asc"
          md-card
          md-fixed-header
          @md-selected="onSelect"
        >
          <md-table-toolbar>
            <div class="md-toolbar-section-start">
              <h1 class="md-title">Team Members</h1>
            </div>

            <md-field md-clearable class="md-toolbar-section-end">
              <md-input placeholder="Search by name..." v-model="search" @input="searchOnTable" />
            </md-field>
          </md-table-toolbar>

          <md-table-empty-state
            md-label="No team member found"
            :md-description="`No team member found. Make sure you have selected the team the member belongs to.`"
          ></md-table-empty-state>

          <md-table-row
            slot="md-table-row"
            slot-scope="{ item }"
            :class="getClass(item)"
            md-selectable="single"
          >
            <md-table-cell md-label="AB Number" md-sort-by="abNumber" md-numeric>{{ item.abNumber }}</md-table-cell>
            <md-table-cell md-label="Full Names" md-sort-by="names">{{ item.names }}</md-table-cell>
            <md-table-cell md-label="Monday" md-sort-by="monday">{{ item.monday }}</md-table-cell>
            <md-table-cell md-label="Tuesday" md-sort-by="tuesday">{{ item.tuesday }}</md-table-cell>
            <md-table-cell md-label="Wednesday" md-sort-by="wednesday">{{ item.wednesday }}</md-table-cell>
            <md-table-cell md-label="Thursday" md-sort-by="thursday">{{ item.thursday }}</md-table-cell>
            <md-table-cell md-label="Friday" md-sort-by="friday">{{ item.friday }}</md-table-cell>
          </md-table-row>
        </md-table>
      </md-card-content>

      <md-card-actions>
        <md-button class="md-raised md-primary" @click="showDialog=true">View Profile</md-button>
        <md-button class="md-raised md-accent" @click="populateTeams()">Remove from Team</md-button>
      </md-card-actions>

      <md-dialog :md-active.sync="showDialog">
        <md-dialog-title>Type of Employee Viewer</md-dialog-title>
        <md-button router-link to="/monthview" class="md-primary md-raised">Monthly View</md-button>
        <md-button router-link to="/weeklyview" class="md-accent md-raised">Weekly View</md-button>
      </md-dialog>
    </md-card>
  </div>
</template>

<script lang="ts">
import { Vue, Watch } from "vue-property-decorator";
import Component from "vue-class-component";
import HomeServices, * as homeServices from "./../services/HomeServices";
import * as Api from "./../api/api";

@Component
export default class HomeTS extends Vue {
  showDialog = false;
  _homeService;
  membersWeekSummary: any;
  teamsApi;
  search = null;
  selected = {};
  selectedTeam = 0;
  teamOptions: any = [];
  searched = [];
  users: any = [];
  personApi: any;
  emotionApi: any;
  emotions: any;
  people: any;
  display: any = [];
  personname: any = [];
  id;
  name: any;
  emotionId;
  percentage: any;
  emotion: any;

  constructor() {
    super();
    this.teamsApi = new Api.TeamsApi();
    this.personApi = new Api.PersonApi();
    this.emotionApi = new Api.EmotionsApi();
  }
  toLower = text => {
    return text.toString().toLowerCase();
  }

  searchByName = (items, term) => {
    if (term) {
      return items.filter(item =>
        this.toLower(item.names).includes(this.toLower(term))
      );
    }
    return items;
  }

  async populateTeams(): Promise<void> {
    this._homeService = new HomeServices();
    /*eslint-disable*/
    let results: any = await this._homeService.retrieveTeams();
    for (var i: any = 0; i < results.length; i++) {
      this.teamOptions.push(results[i]);
    }
  }

  searchOnTable(): void {
    this.searched = this.searchByName(this.users, this.search);
  }

  getClass(id: any): any {
    if (id !== 0) {
      return "md-primary";
    } else {
      return id;
    }
  }

  onSelect(item: any): void {
    this.selected = item;
  }

  mounted(): void {
    this.searchOnTable();
    this.populateTeams();
    this.emotions = this.getAllEmotions();
    this.people = this.getAllPeople();
  }

  @Watch("selectedTeam")
  async teamSelectChange(teamId: any): Promise<void> {
    this._homeService = new HomeServices();
    let teamWeeklyEmotions: any = await this._homeService.retrieveTeamMembersDetails(
      teamId
    );
    this.populateTable(teamWeeklyEmotions);
  }
  async getAllEmotions(): Promise<any> {
    await this.emotionApi.getAllEmotions().then(response => {
      this.emotions = response.data;
    });

    return this.emotions;
  }
  async getAllPeople(): Promise<any> {
    return await this.personApi.getAllPeople().then(response => {
      this.people = response.data;
    });

    return this.people;
  }
  populateTable(teamWeeklyEmotions: any): void {
    console.log(teamWeeklyEmotions);
    for (var i: number = 0; i < teamWeeklyEmotions.length; i++) {
      this.id = teamWeeklyEmotions[i].person_fk;
      this.emotionId = teamWeeklyEmotions[i].emotion_fk;
      this.percentage = teamWeeklyEmotions[i].percentage.toString();
      let daysArray: any[][];
      this.emotion = this.emotions
        .filter(x => x.emotion_id === this.emotionId)
        .map(p => p.emotion_name)
        .toString();
      let days: Map<string, any> = new Map<string, any>();
      let day: any = new Date(teamWeeklyEmotions[i].emotion_date);
      let name: any =this. _homeService.getDay(day);
      let emotionNamePercentage: string =
        this.emotion + " - " + this.percentage;
      days.set(name, emotionNamePercentage);
      console.log(day);

      this.users.push({
        abNumber: this.people
          .filter(x => x.person_id === this.id)
          .map(p => p.abnumber)
          .toString(),
        names: this.people
          .filter(x => x.person_id === this.id)
          .map(p => p.name)
          .toString(),
        monday: days.get("Monday"),
        tuesday: days.get("Tuesday"),
        wednesday: days.get("Wednesday"),
        thursday: days.get("Thursday"),
        friday: days.get("Friday")
      });
    }

    console.log("users: " + this.users);
  }
}
</script>

<style lang="scss" scoped>
.md-layout-item {
  width: 250px;
}
</style>