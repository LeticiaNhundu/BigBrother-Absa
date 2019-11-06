<template>

    <md-card>
        <md-card-header>

            <div class="md-layout">
                <div class="md-layout-item"></div>
                <div class=" md-layout-item">
                    <div class="md-layout">
                        <md-field class="txtAbNumber">
                            <md-input v-model="txtAbnumber" placeholder="AB Number"></md-input>
                            <md-button class="md-primary md-layout-item " @click="searchUser()">
                                <md-icon>search</md-icon>
                            </md-button>
                        </md-field>
                    </div>
                </div>
                <div class="md-layout-item"></div>
            </div>
        </md-card-header>
        <md-card-content>
            <div class="md-layout">
                <div class="md-layout-item"></div>
                <md-card class="videoCard md-layout-item">
                    <md-card-header>
                        <md-toolbar md-elevation="1" class="md-transparent md-layout">
                            <span class="md-caption md-layout-item"><b>Train user model for:</b> {{userNames}}</span>
                            <span class="md-caption md-layout-item"><b>Team:</b> {{userTeam}}</span>
                        </md-toolbar>
                    </md-card-header>
                    <md-card-content>
                        <div class="videoRec text-xs-center">
                            <video ref="video" id="video" width="640" height="480" autoplay></video>
                            <br>
                            <div  v-if="isRecording" class="counter">
                                <slot name="counter">
                                    <div class="content">
                                        <i class="fa fa-circle" aria-hidden="true" style="font-size: 0.5rem;"></i>
                                        {{recordingTime}}
                                    </div>
                                </slot>
                            </div>
                            <br>
                            <div v-if="!isRecording && !isAlreadyRecorded" class="record-button">
                                <button type="button" class="btn btn-primary" @click="startRecording()" >Start Recording</button>&nbsp;&nbsp;
                            </div>
                            <div v-if="isRecording" class="record-button" >
                                <button type="button" class="btn btn-danger" @click="stopRecording()">Stop Recording</button>&nbsp;&nbsp;
                            </div>
                            <div  v-if="!isRecording && isAlreadyRecorded">
                                <button type="button" class="btn btn-primary" @click="download()">Upload</button>&nbsp;&nbsp;
                                <button type="button" class="btn btn-danger" @click="Reset()">Reset</button>
                            </div>
                        </div>
                    </md-card-content>
                </md-card>
                <div class="md-layout-item">
                </div>
            </div>
            <md-dialog :md-active.sync="showDialog">
                <md-dialog-title>Add New Employee</md-dialog-title>
                <md-dialog-content>
                    <md-field>
                        <md-input v-model="abNum" placeholder="AB Number"></md-input>
                    </md-field>
                    <md-field>
                        <md-input v-model="name" placeholder="First Name"></md-input>
                    </md-field>
                    <md-field>
                        <md-input v-model="surname" placeholder="Last Name"></md-input>
                    </md-field>
                    <md-field>
                        <md-select v-model ="selectedTeam" placeholder="Teams">
                            <md-option v-for="teams in teamOptions" :key="teams.team_id" :value="teams.team_id">{{teams.team_name}}</md-option>
                        </md-select>
                    </md-field>
                </md-dialog-content>
                <md-dialog-actions>
                    <md-button class="md-raised md-primary" @click="saveNewEmployee()">Save</md-button>
                    <md-button class="md-raised md-accent" @click="showDialog = false">Cancel</md-button>
                </md-dialog-actions>

            </md-dialog>


            <md-dialog :md-active.sync="showNoResultsDialog">
                <md-dialog-title>No user found.</md-dialog-title>
                <md-dialog-content>
                    There is no user with AB Number: '{{txtAbnumber}}' in our records. Please verify the AB Number or create a new user for that AB Number.
                </md-dialog-content>
                <md-dialog-actions>
                    <md-button class="md-raised md-accent" @click="showNoResultsDialog = false">Ok</md-button>
                </md-dialog-actions>

            </md-dialog>

            <md-dialog :md-active.sync="userExistDialog">
                <md-dialog-title>User Already Exist</md-dialog-title>
                <md-dialog-content>
                    The user already with this AB number already exists.
                </md-dialog-content>
                <md-dialog-actions>
                    <md-button class="md-raised md-accent" @click="userExistDialog = false">Ok</md-button>
                </md-dialog-actions>

            </md-dialog>

            <md-dialog :md-active.sync="showError">
                <md-dialog-title>Error Creating User</md-dialog-title>
                <md-dialog-content>
                    Error: Something went wrong when creating new user. Please contact the administrator.
                </md-dialog-content>
                <md-dialog-actions>
                    <md-button class="md-raised md-accent" @click="showError = false">Ok</md-button>
                </md-dialog-actions>

            </md-dialog>

            <!-- success message -->
            <form novalidate @submit.stop.prevent="showSnackbar = true">
                <md-snackbar :md-duration="isInfinity ? false : duration" :md-active.sync="showSnackbar" md-persistent>
                    <span>Employee has been successfully created!</span>
                    <md-button class="md-primary" @click="showSnackbar = false">Ok</md-button>
                </md-snackbar>
            </form>

        </md-card-content>
        <md-card-actions>
            <md-button class="md-raised md-accent" @click="createNewEmployee()">Add New Employee</md-button>
        </md-card-actions>
    </md-card>


</template>

<script lang ="ts">

    import Vue from "vue";
    import { Component,  Prop } from "vue-property-decorator";
    import  RecordRTC from 'recordrtc/RecordRTC.min';
    import * as Api from "../api/api";
    import TrainerServices from "../services/Trainer";
    @Component
    /*eslint-disable*/
    export default  class  Trainer extends Vue {
        stream;
        isRecording = false;
        txtAbnumber = null;
        txtName = null;
        trainerApi: TrainerServices;
        video;
        userNames: string = "";
        userTeam: string = "";
        recordRTC: any;
        videoModel;
        counter =0;
        homeapi;
        userExistDialog= false;
        timeCounter:any;
        showDialog:any = false;
        showNoResultsDialog: any = false;
        allTeams:any =[];
        isAlreadyRecorded =false;
        mediaConstraints:any = {
            video: {
                mandatory: {
                    minWidth: 1280,
                    minHeight: 720
                }
            },
            audio: false
        };
        poster ="/static/video-camera.png";
        //create user parameters
        abNum:any ="";
        name:any ="";
        surname:any ="";
        selectedTeam:any ="";
        teamOptions: any = [];

        showSnackbar= false;
        position= 'center';
        duration= 4000;
        isInfinity=false;
        showError: boolean = false;

        constructor() {
            super();
            this.homeapi = new Api.VideoApi();
            this.trainerApi = new TrainerServices();
        }



        mounted ():void {
            let video:any = this.$refs.video;
            video.setAttribute("autoplay", true);
            video.removeAttribute("controls");
            if(navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
                navigator.mediaDevices.getUserMedia(this.mediaConstraints).then(stream => {
                    video.srcObject = stream;
                });
            }
        }
        Reset():void {
            let video:any = this.$refs.video;
            navigator.mediaDevices.getUserMedia(this.mediaConstraints).then(stream => {
                video.srcObject = stream;
                this.isAlreadyRecorded = false;
                video.setAttribute("autoplay", true);
                video.removeAttribute("controls");
                video.srcObject = stream;
            });
        }
        get recordingTime (): string {
            const minutes:number = Math.floor(this.counter / 60);
            const seconds:string|number = this.counter % 60 < 10 ? `0${this.counter % 60}` : this.counter % 60;
            return minutes + ":" + seconds;
        }

        processVideo(audioVideoWebMURL:any):void {
            let video: any = this.$refs.video;
            let recordRTC:any = this.recordRTC;
            video.srcObject = null;
            video.src = audioVideoWebMURL;
            var recordedBlob:any = recordRTC.getBlob();
            recordRTC.getDataURL(function (dataURL:any):any {});
        }

        successCallback(stream: MediaStream):void {
            var options:any = {
                mimeType: "video/webm",
                videoBitsPerSecond: 128000,
            };
            this.stream = stream;
            this.recordRTC = RecordRTC(stream, options);
            let video: any = this.$refs.video;
            video.setAttribute("autoplay", true);
            video.removeAttribute("controls");
            video.srcObject = stream;
            video.captureStream = video.captureStream || video.mozCaptureStream;
            this.recordRTC.startRecording(video.captureStream);
        }

        startRecording():void {
            this.$emit("onStart");
            this.time();
            let video: any = this.$refs.video;
            navigator.mediaDevices.getUserMedia(this.mediaConstraints)
                .then(this.successCallback.bind(this));
        }

        time ():void {
            this.isRecording = true;
            this.timeCounter = setInterval(() => {
                this.counter = this.counter + 1;
            }, 1000);
        }

        stopRecording():void {
            this.isAlreadyRecorded =true;
            this.clearInterval();
            let video: any = this.$refs.video;
            let recordRTC:any = this.recordRTC;
            recordRTC.stopRecording(this.processVideo.bind(this));
            let stream:any = this.stream;
            video.removeAttribute("autoplay");
            video.setAttribute("controls", true);
            stream.getAudioTracks().forEach(track => track.stop());
            stream.getVideoTracks().forEach(track => track.stop());
        }

        clearInterval ():void {
            clearInterval(this.timeCounter);
            this.isRecording = false;
            this.counter = 0;
            this.timeCounter = null;
        }

        download():void {
            this.homeapi.postTraining(this.txtAbnumber ,this.recordRTC.getBlob());
            // this.recordRTC.save('video.webm');
        }

        async searchUser() {
            console.log("ab number: "+ this.txtAbnumber);
            let searchUserResults = await this.trainerApi.searchEmployee(this.txtAbnumber);
            if (searchUserResults.status == 200) {
                this.userNames = searchUserResults.data.name + " " + searchUserResults.data.surname;
                this.userTeam = await this.trainerApi.getEmployeeTeam(searchUserResults.data.person_id);
            } else {
                this.showNoResultsDialog = true;
            }
        }

        async createNewEmployee() {
            this.teamOptions = await this.trainerApi.getAllTeams();
            this.showDialog = true;
        }

        async saveNewEmployee() {
            let personModel: Api.Person = {
                abnumber: this.abNum,
                name: this.name,
                surname: this.surname
            };


            let createEmployeeResponse = await this.trainerApi.createEmployee(personModel);
            let employeeId: any;

            if(createEmployeeResponse.status == 200) {
                for (let i = 0; i < createEmployeeResponse.data.length; i++) {
                    if(createEmployeeResponse.data[i].abnumber == personModel.abnumber) {
                        employeeId = createEmployeeResponse.data[i].person_id;
                        break;
                    }
                }

                let teamPersonModel: any = {
                    person_fk: employeeId,
                    team_fk: this.selectedTeam
                };

                let createEmployeeTeam = await this.trainerApi.addEmployeeTeam(teamPersonModel);

                this.showDialog = false;
                this.showSnackbar = true;
            } else if(createEmployeeResponse.status == 204) {
                this.showDialog = false;
                this.userExistDialog = true
            } else {
                console.log(createEmployeeResponse.status);
                this.showDialog = false;
                this.showError = true;
            }

        }
    }
</script>

<style lang="scss" scoped>
    .videoPlayer{
        width: 600px;
        background: gray;
    }

    .video{
        align-items: center;
    }

    .txtAbNumber{
        width:200px;
        border: none;
    }
</style>