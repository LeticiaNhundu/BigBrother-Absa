import * as API from '../api/api';
/*eslint-disable*/
export default class Trainer {

    personApi: API.PersonApi;
    teamPersonApi: API.TeamPersonApi;
    teamPersonModel!: API.TeamPerson;
    teamsApi: API.TeamsApi;
    allTeams: any;

    constructor() {
        this.personApi = new API.PersonApi();
        this.teamPersonApi = new API.TeamPersonApi();
        this.teamsApi = new API.TeamsApi();
    }

    async getAllTeams() {
        let teams: any = [];
        await this.teamsApi.getAllTeams().then(response => {
            for (var i = 0; i < response.data.length; i++) {
                teams.push(response.data[i]);
            }
        });
        return teams;
    }

    async searchEmployee(abNumber) {
        let person: any;
        await this.personApi.getPerson(abNumber).then(response => {
            person = response;
        });
        return person;
    }

    async getEmployeeTeam(personId) {
        let allTeams = await this.getAllTeams();
        let employeeTeam: any;
        let teamName: string = "";

        await this.teamPersonApi.getByPerson(personId).then(response => {
            employeeTeam = response.data[0];
        });


        nameSearch: for (var i = 0; i < allTeams.length; i++) {
            if (allTeams[i].team_id == employeeTeam.team_fk) {
                teamName = allTeams[i].team_name;
                break nameSearch;
            }
        }

        return teamName;
    }

    async createEmployee(person) {
        let result: any = null;
        await this.personApi.savePerson(person).then(response => {
            result = response
        });

        return result;

    }

    async addEmployeeTeam(teamPerson: API.TeamPerson) {
        let result: any;
        await this.teamPersonApi.insert(teamPerson).then(response => {
            result = response;
        });
        return result;
    }




}