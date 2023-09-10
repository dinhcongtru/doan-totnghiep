<template>
    <div class="container">
        <div class="cf"></div>
        <div class="main">
            <div class="breadcrumb">
                <a>Trang chủ</a> » <a>Tin tức</a>
            </div>
            <div class="thirteen columns" id="main_content">
                <div class="box">
                    <div class="box_ct news_page">
                        <ul>
                            <li class="one-third column" v-for="(item,index) in listNews" :key="index">
                                <article class="news_item">
                                    <figure class="img_news">
                                        <router-link :to="{name :'newsDetailt', query :{name : item.url}}">
                                            <img class="lazyautosizes lazyloaded" :src="item.img"  :alt="item.alt" sizes="248px">
                                        </router-link>
                                    </figure>
                                    <h2 class="title_news">
                                        <router-link :to="{name :'newsDetailt', query :{name : item.url}}">{{ item.titleContent }}</router-link>
                                    </h2>
                                    <div class="description_news">
                                        {{ item.description }}
                                    </div>
                                    <router-link :to="{name :'newsDetailt', query :{name : item.url}}" class="readmore"><em>Xem thêm</em></router-link>
                                </article>
                            </li>
                        </ul>
                        <div class="pagination padd10">
                            <div class="paginator">
                                <span class="labelPages">1 - 12 / 12</span>
                                <span class="titlePages">&nbsp;&nbsp;Trang: </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import { listNews } from '@/resource/TestData'
export default {
    name: "TinTuc",
    created(){
        document.title = this.$route.meta.title
    },
    data(){
        return{
            listNews : listNews
        }
    }
}
</script>
<style scoped>
*,body{
    font-size: 14px;
    font-family: 'Quicksand', sans-serif;
}
    .container {
    padding-right: 15px;
    padding-left: 15px;
    margin-right: auto;
    margin-left: auto;
}
@media (min-width: 768px){
.container {
    width: 750px;
}
}
@media (min-width: 992px){
.container {
    width: 970px;
}
}
.container {
    margin: 0 auto;
}
@media (min-width: 768px){
.container {
    width: 750px;
}
}
@media (min-width: 992px){
.container {
    width: 970px;
}
}
@media (min-width: 1024px){
.container {
    width: 1000px;
    padding: 0;
}
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
#main:after, .box:after, .box_ct:after, .cf:after, .container:after, .news_item:after, .pagination:after {
    clear: both;
    content: "";
    display: block;
    height: 0;
}
#main {
    padding-top: 10px;
}
.breadcrumb {
    padding: 8px 15px;
    margin-bottom: 20px;
    list-style: none;
    background-color: #f5f5f5;
    border-radius: 4px;
}
.breadcrumb {
    font-style: italic;
    margin-bottom: 10px;
}
a {
    background-color: transparent;
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

.breadcrumb a:first-child {
    padding-left: 0;
}

.breadcrumb a {
    padding: 0 5px;
}
a {
    transition: opacity 150ms linear, color 150ms linear, background 150ms linear;
}
.container .column, .container .columns {
    float: left;
    display: inline;
    margin-left: 0;
    margin-right: 0;
}
.container .thirteen.columns {
    width: 81.25%;
}
@media only screen and (min-width: 992px) and (max-width: 1263px){
#main_content {
    width: 78% !important;
}
}
#main_content {
    width: 100%;
}
.box {
    float: left;
    width: 100%;
    margin-bottom: 20px;
}

.box, .box_Tab, .tab_cate_main {
    position: relative;
}
.news_page ul {
    margin-left: -15px;
}

ul {
    padding: 0;
    list-style-type: none;
}
ol, ul {
    margin-top: 0;
    margin-bottom: 10px;
}
.container .one-third.column {
    width: 33.3%;
}

@media only screen and (min-width: 992px){
.news_page li:nth-child(3n+1) {
    clear: both;
}
}
.container .column, .container .columns {
    float: left;
    display: inline;
    margin-left: 0;
    margin-right: 0;
}
article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary {
    display: block;
}
article, aside, details, figcaption, figure, dialog, footer, header, hgroup, menu, nav, section {
    display: block;
}
.news_page .news_item {
    margin: 15px 0 15px 15px;
    line-height: 1.3;
}
figure {
    margin: 0;
}
.news_page .news_item .img_news {
    text-align: center;
    overflow: hidden;
    border: 1px solid #ddd;
    margin-bottom: 10px;
}
.img_news a {
    display: block;
    width: 100%;
    height: 240px;
    margin: auto;
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
img.lazyloaded {
    opacity: 1;
    transition: 0.3s;
}
.news_page .news_item .img_news img, .news-img img {
    object-fit: cover;
}
.news_page .news_item .img_news img {
    width: 100%;
    height: 100%;
    object-fit: scale-down;
}
h1, h2, h3, h4, h5, h6 {
    color: #252a2b;
    margin: 0 0 13px 0;
    font-weight: 500;
    line-height: 1.2;
}

.news_item .title_news {
    font-size: 1em;
}
h1 a, h2 a, h3 a, h4 a, h5 a, h6 a {
    color: #252a2b;
    line-height: 1.1;
    font-family: 'Quicksand-Bold';
}

.news_item .description_news {
    display: block;
    height: 88px;
    overflow: hidden;
}

.news_item .readmore {
    white-space: nowrap;
    color: red;
    padding-left: 10px;
}
em {
    font-style: italic;
    color: red;
}
.pagination {
    background: #f5f5f5;
    margin-top: 20px;
    font-size: .9em;
    text-align: center;
}

.pagination {
    display: inline-block;
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
}
.pagination .paginator .labelPages, .pagination .paginator .titlePages {
    display: none;
}
.news_page ul:after {
    content: "";
    display: block;
    clear: both;
}

@media (min-width: 1200px){
.container {
    width: 1170px;
    padding: 0;
}
}
</style>