function loadRepos() {
   const btn = document.querySelector('button');
   btn.addEventListener('click', function load() {
      const url = 'https://api.github.com/users/testnakov/repos';
      const xmlHttpRequest = new XMLHttpRequest();
      xmlHttpRequest.addEventListener('readystatechange', () => {
         if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {
            document.getElementById("res").textContent = xmlHttpRequest.responseText;
         }
      });
      xmlHttpRequest.open('GET', url);
      xmlHttpRequest.send();
   });
}