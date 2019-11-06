<template>

    <md-card>
        <md-card-header>
         
            <div class="md-layout">
                <div class="md-layout-item"></div>
                <div class=" md-layout-item">
                    <div class="md-layout">
                        <md-field class="txtAbNumber">
                            <md-input v-model="txtAbnumber" placeholder="AB Number"></md-input>
                            <md-button class="md-primary md-layout-item md-raised">
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
                        <md-toolbar md-elevation="1" class="md-transparent">
                            <span class="md-caption">Training</span>
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
  


                        <md-field class="txtAbNumber">
                            <md-input class="md-raise" value="Themba Baloyi"></md-input>
                        </md-field>
                        <md-field class="txtAbNumber">
                            <md-select class="md-raise">
                                <md-option value="a" >The Folks Team</md-option>
                                <md-option value="b">The Dariel Team</md-option>
                                <md-option value="c">The Absa Team</md-option>
                            </md-select>
                        </md-field>
                    </md-card-content>
                </md-card>
                <div class="md-layout-item"> 
                </div>
            </div>
            <md-dialog :md-active.sync="showDialog">
                <md-dialog-title>Add New Employee</md-dialog-title>
                <md-dialog-content>
                    <md-field>
                        <md-input placeholder="First Name"></md-input>
                    </md-field>
                    <md-field>
                        <md-input placeholder="Last Name"></md-input>
                    </md-field>
                    <md-field>
                        <md-select placeholder="Team">
                            <md-option value="dariel">The Voice Folks</md-option>
                            <md-option value="dariel">The Dariel Team</md-option>
                            <md-option value="absa">The Absa Team</md-option>
                        </md-select>
                    </md-field>
                </md-dialog-content>
                <md-dialog-actions>
                    <md-button class="md-raised md-primary">Save</md-button>
                    <md-button class="md-raised md-accent" @click="showDialog = false">Cancel</md-button>
                </md-dialog-actions>
                
            </md-dialog>
            
        </md-card-content>
        <md-card-actions>
            <md-button class="md-raised md-primary">Save Employee</md-button>
            <md-button class="md-raised md-accent" @click="showDialog = true">Add New Employee</md-button>
        </md-card-actions>
    </md-card>
    
</template>

<script lang ="ts">

import axios from "axios";
import Vue from "vue";
import WebCam from "vue-web-cam";
import { Component,  Prop } from "vue-property-decorator";
import  RecordRTC from "recordrtc/RecordRTC.min";
import * as Api from "../api/api";
@Component

export default  class  Trainer extends Vue {

stream;
isRecording = false;
video;
recordRTC: any;
 videoModel;
 counter =0;
 homeapi;
 txtAbnumber;
 timeCounter:any;

 isAlreadyRecorded =false;
  mediaConstraints:any = {
      video: {
        mandatory: {
          minWidth: 1280,
          minHeight: 720
        }
      }, audio: false
    };
 poster ="/static/video-camera.png";
constructor() {
  super();
this.homeapi = new Api. VideoApi();
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
    navigator.mediaDevices
      .getUserMedia(this.mediaConstraints)
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
                let video:Blob =this.recordRTC.getBlob();
                this.homeapi.postTraining(this.txtAbnumber,video);
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