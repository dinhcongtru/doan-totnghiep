<template>
     <section class="sec-pro">
            <div class="sec-head">
                <h1>{{ labelText }}</h1>
            </div>
            <div class="list-album">
                <span v-for="(item,index) in listAlbum" :key="index">
                    <div class="album">
                        <a :href="item.urlAlbum">
                            <img class="img-main1" :src="require('@/assets/img/' + item.imgAlbum)" alt="">
                            <div class="name-pro">{{ item.text }}</div>
                        </a>
                        <div class="mota" v-show="isHasDescribe">
                            <div class="describe">{{ item.describe }}</div>
                            <a :href="item.urlXemthem">{{ item.textA }}</a>
                        </div>
                    </div>
                </span>
            </div>
    </section>
</template>
<script>
export default{
    name : "AlBum",
    props:{
        //label textAlbum
        labelText :{
            type:String,
            default: "default text"
        },
        // có mô tả hay không
        isHasDescribe:{
            type:Boolean,
            default:false // mắc định là false
        },
         //danh sách album
         listAlbum:{
            type:Array,
            default: () => [
                {
                    urlAlbum : "#",
                    imgAlbum : "alb2.webp",
                    text : "default",
                    describe : "mô tả default",
                    urlXemthem : "#",
                    textA : "Xem Thêm"
                }
            ]
        }
    },
    
    
}
</script>
<style scoped>
.sec-pro{
    padding: 0 50px;
    margin-bottom: 30px;

}
.list-album{
    display: flex;
    flex-wrap: wrap;
    width: 100%;
}
.list-album > span{
    width: calc(100% / 4);
    padding: 0 15px ;

}
.list-album > span > .album{
    width: 100%;
}
.album > a{
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: start;
    justify-content: left;
}
.album > a > img{
    width: 100%;
}
.name-pro{
    text-transform: uppercase;
    color: #252a2b;
    font-size:17px;
    font-weight: 600;
    line-height: 1.1;
    margin: 13px 0;
}
.describe{
    color: #666;
    text-align: left;
    display: block;
    font-size: 14px;
    text-overflow: ellipsis;
    overflow: hidden;
    height: 55px;
    margin-bottom: 13px;
}
.mota > a{
    font-size: 14px;
    color: #a94442;
}
</style>