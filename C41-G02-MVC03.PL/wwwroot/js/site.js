var SearchInput = Document.getElementById("SearchInput")
SearchInput.addEventListener("keyup", function () {
	function run() {

		// Creating Our XMLHttpRequest object 
		let xhr = new XMLHttpRequest();

		// Making our connection 
		let url = 'https://localhost:44303/Employee/Index?SearchInput=${SearchInput.value}';
		xhr.open("POST", url, true);

		// function execute after request is successful 
		xhr.onreadystatechange = function () {
			if (this.readyState == 4 && this.status == 200) {
				console.log(this.response);
			}
		}
		// Sending our request 
		xhr.send();
	}
	run();

})