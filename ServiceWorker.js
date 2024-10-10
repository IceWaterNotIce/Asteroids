const cacheName = "DefaultCompany-Asteroids-Unity-1.0";
const contentToCache = [
    "Build/Web.loader.js",
    "Build/9556dadfd612f6acbacf9df9d1f5a83c.js",
    "Build/cacc2b3833994fe047c9cd015538d848.data",
    "Build/2dba92c285fe3343cab606f29caf66bf.wasm",
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
