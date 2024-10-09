const cacheName = "DefaultCompany-Asteroids-Unity-1.0";
const contentToCache = [
    "Build/Web.loader.js",
    "Build/0b92ae48513d70ae238628b29238359d.js",
    "Build/7587886acf6f21166f50e79d284b59c7.data",
    "Build/acca1bf6dec34518fc81531e264c17ce.wasm",
    "TemplateData/style.css"

];

self.addEventListener('install', function (e) {
    console.log('[Service Worker] Install');
    
    e.waitUntil((async function () {
      const cache = await caches.open(cacheName);
      console.log('[Service Worker] Caching all: app shell and content');
      await cache.addAll(contentToCache);
    })());
});

self.addEventListener('fetch', function (e) {
    e.respondWith((async function () {
      let response = await caches.match(e.request);
      console.log(`[Service Worker] Fetching resource: ${e.request.url}`);
      if (response) { return response; }

      response = await fetch(e.request);
      const cache = await caches.open(cacheName);
      console.log(`[Service Worker] Caching new resource: ${e.request.url}`);
      cache.put(e.request, response.clone());
      return response;
    })());
});
