<template>
    <main class="main-site main-childs">
        <div class="user-wrapper">
            <div class="user-nav anonymous-awe">
                <a class="active" rel="nofollow">Quên mật khẩu</a>
            </div>
            <form action="" id="UserGetActiveCode" class="f">
                <ul>
                    <li>
                        <label for="newpassword" class="required"><span>*</span> Nhập địa chỉ email:</label>
                        <input name="inputStr" type="text" class="tb" id="newpassword" value="">
                    </li>
                    <li class="btns">
                        <input name="submit" type="submit" id="btnSubmit" class="htmlBtn first" value="Xác nhận">
                    </li>
                </ul>
            </form>
        </div>
    </main>
</template>
<script>
export default {
    name:"getPassword",
    created(){
        document.title = this.$route.meta.title
    }
}
</script>
<style scoped>
*,body{
    font-size: 14px;
}
main{
    margin-bottom: 50px;
}
article, aside, details, figcaption, figure, footer, header, hgroup, main, menu, nav, section, summary{
    display: block;
}
.user-wrapper {
    max-width: 600px;
    margin: auto;
    border: 1px solid #ccc;
}
.user-nav {
    border-bottom: 2px solid #cccccc63;
    overflow: hidden;
    box-shadow: 0 1px 3px rgba(146, 146, 146, 0.14);
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
.user-nav a {
    width: 100%;
    /* float: left; */
    display: inline-block;
    text-transform: uppercase;
    font-size: 18px;
    text-align: center;
    padding: 5px 10px;
    border-bottom: 2px solid transparent;
}
.user-nav a.active, .user-nav a:hover {
    border-bottom: 2px solid #10a2f7;
}
.user-wrapper form {
    padding: 20px;
}
ul {
    padding: 0;
    list-style-type: none;
}

ol, ul {
    margin-top: 0;
    margin-bottom: 10px;
}
.user-wrapper form li {
    width: 100%;
    clear: both;
    list-style: none;
    display: inline-block;
}
label {
    display: inline-block;
    max-width: 100%;
    margin-bottom: 5px;
    font-weight: 700;
}
button, input, optgroup, select, textarea {
    margin: 0;
    font: inherit;
    color: inherit;
}
input {
    line-height: normal;
}
button, input, select, textarea {
    font-family: inherit;
    font-size: inherit;
    line-height: inherit;
}
.user-wrapper form li input, .user-wrapper form li button {
    padding: 8px 12px;
    width: 100%;
    clear: both;
    list-style: none;
    display: inline-block;
}
.user-wrapper form li input[name="inputStr"] {
    border: 1px solid #ccc;
    border-radius: 5px;
    margin: 10px 0;
}
.user-wrapper form li {
    width: 100%;
    clear: both;
    list-style: none;
    display: inline-block;
}
button, html input[type=button], input[type=reset], input[type=submit] {
    appearance: auto;
    -webkit-appearance: button;
    cursor: pointer;
}
#btnSubmit {
    color: #fff;
    text-transform: uppercase;
    font-size: 18px;
    border: none;
    background: #fd6e1d;
    background: -webkit-gradient(linear,0% 0%,0% 100%,from(#fd6e1d),to(#f59000));
    background: -webkit-linear-gradient(top,#f59000,#fd6e1d);
    background: -moz-linear-gradient(top,#f59000,#fd6e1d);
    background: -ms-linear-gradient(top,#f59000,#fd6e1d);
    background: -o-linear-gradient(top,#f59000,#fd6e1d);
}
#btnSubmit, #btnSubmit:hover, #btnSubmit:focus {
    outline: 0;
}
</style>