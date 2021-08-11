/*!CK:394085562!*//*1449009298,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["d3ume"]); }

__d('getBlockNumberAndOffsetFromText',['splitTextIntoTextBlocks'],function a(b,c,d,e,f,g,h){'use strict';if(c.__markCompiled)c.__markCompiled();function i(j,k){var l=j.slice(0,k),m=h(l),n=m.map(function(p){return p.length;}).slice(0,-1),o=n.reduce(function(p,q){return p+q+1;},0);return {block:m.length-1,offset:k-o};}f.exports=i;},null);