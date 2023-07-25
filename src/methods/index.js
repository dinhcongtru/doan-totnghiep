import unorm from "unorm"; // Import thư viện unorm
function dynamicUrlProduct(namePro){
    let newStr = namePro.toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/\s+/g, "-");
    return `${newStr}`
}
function convertNameSingin(name) {
    const words = name.trim().toLowerCase().split(" ");
    const newWords = words.map((word) => {
      const firstLetter = word.slice(0, 1).toUpperCase(); // Lấy ký tự đầu tiên và viết hoa
      const restLetters = word.slice(1); // Lấy các ký tự còn lại
      const normalized = unorm.nfc(firstLetter + restLetters); // Thêm dấu vào các chữ cái

      return normalized;
    });
    const newString = newWords.join(" ");
    return newString;
  }
export{dynamicUrlProduct,convertNameSingin}