<template>
  <main>
        <div id="collection" class="collection-page">
            <div class="main-content container-fluid">
                <div class="row">
                    <div class=" banner-collection-header"></div>
                </div>
                <div class="row breadcrumb-shop">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pd5">
                        <ul class="breadcrumb">
                            <li><a href="/">Trang chủ</a></li>
                            <li><a href="/album">Album</a></li>
                            <li><a href="/album">Look Book</a></li>
                        </ul>
                    </div>
                </div>
                <div class="row">
                    <div id="collection-body" class="wrap-collection-body clearfix">
                        
                        <div class="col-md-10 col-sm-12 col-xs-12 pull-right">
                            <div id="resultAjax" class="row filter-here">
                                <div class="content-album-list filter clearfix">
                                    <div class="col-lg-4 col-md-4 col-xs-12 col-sm-12 itemAlbums" :class="{'clear-bot' : item.clear}" v-for="(item,index) in listAlbum" :key="index">
                                        <a :href="item.href" :title="item.title">
                                            <img :src="item.img" :alt="item.alt">
                                            <span>{{ item.content }}</span>
                                        </a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="text-center col-xs-12">
                            <div class="paginator">
                                <span class="labelPages">1 - 9 / 9</span>
                                <span class="titlePages">&nbsp;&nbsp;Trang: </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</template>

<script>
import { listAlbums } from '@/resource/TestData'
export default {
    name:"LookBook",
    data(){
        return{
            listAlbum : listAlbums
        }
    },
    created(){
        document.title = this.$route.meta.title
    }
}
</script>

<style scoped>
    *,body{
    font-size: 14px;
}
article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}
.container-fluid {
    padding-right: 15px;
    padding-left: 15px;
    margin-right: auto;
    margin-left: auto;
}
.container-fluid {
    padding: 0 40px;
}
.btn-group-vertical > .btn-group:after, .btn-group-vertical > .btn-group:before, .btn-toolbar:after, .btn-toolbar:before, .clearfix:after, .clearfix:before, .container-fluid:after, .container-fluid:before, .container:after, .container:before, .dl-horizontal dd:after, .dl-horizontal dd:before, .form-horizontal .form-group:after, .form-horizontal .form-group:before, .modal-footer:after, .modal-footer:before, .nav:after, .nav:before, .navbar-collapse:after, .navbar-collapse:before, .navbar-header:after, .navbar-header:before, .navbar:after, .navbar:before, .pager:after, .pager:before, .panel-body:after, .panel-body:before, .row:after, .row:before {
    display: table;
    content: " ";
}

:after, :before {
    -webkit-box-sizing: border-box;
    -moz-box-sizing: border-box;
    box-sizing: border-box;
}
.row {
    margin-right: -15px;
    margin-left: -15px;
}
.banner-collection-header {
    text-align: center;
}
.btn-group-vertical > .btn-group:after, .btn-toolbar:after, .clearfix:after, .container-fluid:after, .container:after, .dl-horizontal dd:after, .form-horizontal .form-group:after, .modal-footer:after, .nav:after, .navbar-collapse:after, .navbar-header:after, .navbar:after, .pager:after, .panel-body:after, .row:after {
    clear: both;
}
.breadcrumb-shop {
    box-shadow: inset 0 5px 7px 1px #e9e9e9;
}

.row {
    margin-right: -15px;
    margin-left: -15px;
}
.pd5 {
    background: #f5f5f5;
}
.col-lg-1, .col-lg-10, .col-lg-11, .col-lg-12, .col-lg-2, .col-lg-3, .col-lg-4, .col-lg-5, .col-lg-6, .col-lg-7, .col-lg-8, .col-lg-9, .col-md-1, .col-md-10, .col-md-11, .col-md-12, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-sm-1, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, .col-xs-1, .col-xs-10, .col-xs-11, .col-xs-12, .col-xs-2, .col-xs-3, .col-xs-4, .col-xs-5, .col-xs-6, .col-xs-7, .col-xs-8, .col-xs-9, .col-xs-15, .col-sm-15, .col-md-15, .col-lg-15 {
    position: relative;
    min-height: 1px;
    padding-right: 15px;
    padding-left: 15px;
}
.col-xs-1, .col-xs-10, .col-xs-11, .col-xs-12, .col-xs-2, .col-xs-3, .col-xs-4, .col-xs-5, .col-xs-6, .col-xs-7, .col-xs-8, .col-xs-9, .col-xs-15 {
    float: left;
}
.col-xs-12 {
    width: 100%;
}
@media (min-width: 768px){
.col-sm-1, .col-sm-10, .col-sm-11, .col-sm-12, .col-sm-2, .col-sm-3, .col-sm-4, .col-sm-5, .col-sm-6, .col-sm-7, .col-sm-8, .col-sm-9, col-sm-15 {
    float: left;
}    
}
@media (min-width: 768px){
.col-sm-12 {
    width: 100%;
}
}
@media (min-width: 992px){
.col-md-1, .col-md-10, .col-md-11, .col-md-12, .col-md-2, .col-md-3, .col-md-4, .col-md-5, .col-md-6, .col-md-7, .col-md-8, .col-md-9, .col-md-15 {
    float: left;
}
}
@media (min-width: 992px){
.col-md-12 {
    width: 100%;
}
}
ol, ul {
    margin-top: 0;
    margin-bottom: 10px;
}
ul {
    padding: 0;
    list-style-type: none;
}
.breadcrumb {
    padding: 8px 15px;
    margin-bottom: 20px;
    list-style: none;
    background-color: #f5f5f5;
    border-radius: 4px;
}
.breadcrumb > li {
    display: inline-block;
}
.breadcrumb > li {
    float: left;
    display: initial;
}
a {
    background-color: transparent;
}
a {
    color: #337ab7;
    text-decoration: none;
}
a {
    color: #252a2b;
    text-decoration: none;
    outline: none;
    -moz-transition: all 0.2s ease-in-out;
    -o-transition: all 0.2s ease-in-out;
    -webkit-transition: all 0.2s ease-in-out;
    transition: all 0.2s ease-in-out;
}
a {
    transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}
.breadcrumb > li + li:before {
    padding: 0 5px;
    color: #ccc;
    content: "/\00a0";
}
.breadcrumb > li + li:before {
    padding: 0 5px;
    color: #ccc;
    content: "|";
}
.breadcrumb-shop .breadcrumb > li + li:before {
    padding: 0 3px;
}
.breadcrumb-shop .breadcrumb > li + li:before {
    padding: 0 10px;
}
.row {
    margin-right: -15px;
    margin-left: -15px;
}
#collection-body {
    margin: 0 0 50px 0;
}
@media (min-width: 992px){
.col-md-2 {
    width: 16.66666667%;
}
}
@media (min-width: 992px){
.sidebar-fix {
    position: -webkit-sticky;
    position: sticky;
    top: 50px;
    margin-top: 50px;
}
}
.visible-lg, .visible-md, .visible-sm, .visible-xs {
    display: none!important;
}

p {
    margin: 0 0 10px 0;
    line-height: 21px;
}
.fa{
    display: inline-block;
    font: normal normal normal 14px/1 FontAwesome;
    font-size: inherit;
    text-rendering: auto;
    -webkit-font-smoothing: antialiased;
    margin-left: 3px;
}
.tree-menu li a {
    padding: 5px 5px 5px 0;
    color: #666;
    line-height: 26px;
    font-size: 12px;
}
.tree-menu > li > a {
    color: #252a2b;
    font-weight: 500;
    font-size: 14px;
    line-height: 28px;
    letter-spacing: 1px;
}
.tree-menu li a .icon-control {
    font-size: 8px;
    position: relative;
    top: -2px;
}
ol ol, ol ul, ul ol, ul ul {
    margin-bottom: 0;
}
.tree-menu li.has-child ul {
    display: none;
}
.tree-menu li.has-child:first-child ul {
    display: block;
}

.tree-menu li.has-child > ul {
    padding-left: 15px;
}
.tree-menu li a {
    padding: 5px 5px 5px 0;
    color: #666;
    line-height: 26px;
    font-size: 12px;
}
@media (min-width: 1100px){
.pull-right {
    margin-top: 50px;
}
}
@media (min-width: 992px){
.col-md-10 {
    width: 83.33333333%;
}
}
.pull-right {
    float: right!important;
}
.pull-right {
    float: right;
}
.itemAlbums {
    margin-bottom: 20px;
    overflow: hidden;
}
@media (min-width: 992px){
.col-md-4 {
    width: 33.33333333%;
}
}
.itemAlbums a {
    display: block;
}
img {
    border: 0;
}
img {
    vertical-align: middle;
}
img {
    max-width: 100%;
}
.itemAlbums img {
    object-fit: cover;
    width: 100%;
    height: 238px;
}
.itemAlbums span {
    position: absolute;
    left: 0;
    right: 0;
    text-align: center;
    font-size: 20px;
    text-transform: uppercase;
    top: 50%;
    color: #ffff;
    font-weight: 700;
    opacity: .9;
    text-shadow: 4px 4px 5px #000;
}
.text-center {
    text-align: center;
}
@media (min-width: 1025px){
.content-product-list:not(.fixBox) > div:nth-child(4n+1) {
    clear: both;
}
}
.clear-bot{
    clear: both;
}
</style>