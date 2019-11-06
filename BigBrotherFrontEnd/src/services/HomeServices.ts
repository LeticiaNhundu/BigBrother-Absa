import * as API from "./../api/api";

/*eslint-disable*/
export default  class HomeServices {
    teamApi: any;
    personApi: any;
    personTeamApi: any;
    personEmotionApi: any;
    emotionApi: any;
    abnumber:any;
    fullname:any;
    emotion:any;
    public teamsList: any = [];
    emotionDisplay:any= [];
     max:any=[];

    public constructor() {
        this.teamApi = new API.TeamsApi();
        this.personApi = new API.PersonApi();
        this.personTeamApi = new API.TeamPersonApi();
        this.personEmotionApi = new API.PersonEmotionApi();
        this.emotionApi = new API.EmotionsApi();
    }

   async retrieveTeams():Promise<any> {
        console.log("loading teams...");
       await this.teamApi.getAllTeams().then(response =>{
            for(var i:number = 0; i < response.data.length; i++) {
              this.teamsList.push(response.data[i]);
            }
        });
        return this.teamsList;
    }

    async retrieveTeamMembersDetails(teamId:any):Promise<any> {

        console.log("loading people in team details...");
        // get All Team Members
        let teamMembers:any = await this.getTeamMembers(teamId);

        // get All team member's information and return that
        let teamMembersInfo:any = await this.getTeamMembersInfo(teamMembers);

        // get members emotion for the week
        let allWeeklyEmotions:any =  await this.getWeeklyEmotions();

    let results:any;
    let results1:any;
    // tslint:disable-next-line:typedef
    results = allWeeklyEmotions.reduce(function (r, a) {
        // tslint:disable-next-line:no-unused-expression
        r[a.person_fk] = r[a.person_fk] // &&
         // r[a.emotion_date] === r[a.emotion_date]
          || [];
        r[a.person_fk].push(a);
        return r;
    }, Object.create(null));
    // tslint:disable-next-line:typedef
    Object.keys(results).forEach(element => {
    // tslint:disable-next-line:typedef
    results1 = results[element].reduce(function (x, b) {
        // tslint:disable-next-line:no-unused-expression
        x[b.emotion_date] = x[b.emotion_date] // &&
         // r[a.emotion_date] === r[a.emotion_date]
          || [];
        x[b.emotion_date].push(b);
       return x;
    }, Object.create(null));
    console.log(results1);
    let maxPercentageRow:any=[];
    let maxArray:any =[];
 Object.keys(results1).forEach(element => {
    maxPercentageRow= results1[element].reduce((acc, val) => {

           acc = ( acc.percentage === undefined || val.percentage > acc.percentage) ? val : acc;
           return acc;

        }, []);
        maxArray.push( maxPercentageRow);
        });
 // console.log(maxArray);
 // maxArray.array.forEach(element => {
 // });
 this.max.push(maxArray);
      //   return maxArray;
});
console.log(this.max);
return this.max ;

    }

    async getMembersWeeklyEmotions(allWeeklyEmotions: any[], teamMembers: any []):Promise<any> {
        let weeklyMembersEmotions: any = [];

        for (var k:number = 0; k < teamMembers.length; k++) {
            for (var i:number = 0; i < allWeeklyEmotions.length; i++) {
                let dayEmotion: any = [];
                if(teamMembers[k].person_id === allWeeklyEmotions[i].person_fk) {

                    let dayName:any = this.getDay(allWeeklyEmotions[i].emotion_date);
                    let emotionName:any  = await this.getEmotionById(allWeeklyEmotions[i].emotion_fk);
                    let emotionPercentage:any = allWeeklyEmotions[i].percentage + "%";
                    dayEmotion.push({
                        "day": dayName,
                        "emotion":emotionName,
                        "emotionPercentage": emotionPercentage
                    });
                }
//

                weeklyMembersEmotions.push({
                    "abNumber": teamMembers[k].abnumber,
                    "names": teamMembers[k].name + ""+teamMembers[k].surname,
                    "daysEmotions": dayEmotion
                });
            }
        }
        return weeklyMembersEmotions;
    }

    async getAllEmotions():Promise<any> {
        let emotions:any;
        await this.emotionApi.getAllEmotions().then( response => {
            emotions = response.data;
        });

        return emotions;
    }
    async getAllPeople():Promise<any> {
        let people:any;
        await this.personApi.getAllPeople().then( response => {
            people = response.data;
        });

        return people;
    }
    async getEmotionById(emotionId:any):Promise<any> {
        let emotionName:any;
        await this.emotionApi.getEmotion(emotionId).then( response => {
            emotionName = response.data.emotion_name;
        });

        return emotionName;
    }
    private getDay(date:any):any {
       const day:any =  new Date(date).getDay();
       let dayName: any = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday","Sunday"];

       return dayName[day - 1];
    }

    async getWeeklyEmotions():Promise<any> {
        let weeklyDates:void = this.getThisWeekRange();
        let allWeeklyPersonEmotions:any = [];
        await this.personEmotionApi.getAllPersonEmotionByDate(new Date(weeklyDates[0]), new Date(weeklyDates[6])).then( response => {
           // console.log("length" + response.data[0].emotion_date);
            for(var i:number =0; i <response.data.length; i++) {
                allWeeklyPersonEmotions.push(response.data[i]);
            }
        });
        return allWeeklyPersonEmotions;
    }

    // returns all dates of the week from monday to sunday
    private getThisWeekRange():void {
        console.log("Get weekly dates");
        let currentDate:Date = new Date;
        let week: any = [];

        for( var i:number = 1; i <= 7; i++) {
            let firstDay:number = currentDate.getDate() - currentDate.getDay() + i;
            let day:string = new Date(currentDate.setDate(firstDay)).toISOString().slice(0,10);
            week.push(day);
        }
        return week;
    }


    private async getTeamMembers(teamId:any):Promise<any> {
        let teamMembers: any = [];
        // get all the team members
        await this.personTeamApi.getByTeam(teamId).then( response => {
            for(var i:number = 0; i < response.data.length; i++) {
                teamMembers.push(response.data[i]);
            }
        });
        return teamMembers;
    }

    private async getTeamMembersInfo(members:any[]):Promise<any> {
        console.log("finding members full information...");

        let membersFullInfo:any = [];
        for( var y:number = 0; y < members.length; y++) {
            await this.personApi.getPersonBy(members[y].person_fk).then( response => {
                membersFullInfo.push(response.data);
            });
        }
        return membersFullInfo;
    }
}