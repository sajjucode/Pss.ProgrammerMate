/*!CK:1151297331!*//*1447272444,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["KzNCV"]); }

__d('ArticleChainingHide',['AsyncRequest','AttachmentRelatedShareConstants','ContextualThing','CSS','DOM','DOMQuery','Event','XPubcontentChainingHideController','csx','tidyEvent'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q){if(c.__markCompiled)c.__markCompiled();var r={listenForQuickHide:function(s,t,u,v,w,x){q(n.listen(s,'click',function(){var y=m.find(t,"^._1ui8"),z=m.find(y,"._3f-c"),aa=m.find(y,"._3f-d");k.hide(z);setTimeout(function(){var ba=j.getContext(t),ca=o.getURIBuilder(),da=ba&&JSON.parse(ba.getAttribute('data-ft'))||{};da.object_id=v;da.reason=x;da.chaining_type=w;if(u)da.qid=u;new h().setMethod('POST').setURI(ca.getURI()).setData(da).setRelativeTo(t).send();},i.HIDE_DELAY);k.show(aa);}));},listenForUndoLink:function(s,t,u,v){q(n.listen(s,'click',function(){var w=m.find(t,"^._1ui8"),x=m.find(w,"._3f-c");k.hide(t);setTimeout(function(){var y=j.getContext(t),z='/pubcontent/chaining/unhide',aa=y&&JSON.parse(y.getAttribute('data-ft'))||{};aa.object_id=u;aa.chaining_type=v;new h().setMethod('POST').setURI(z).setData(aa).setRelativeTo(t).send();},i.HIDE_DELAY);k.show(x);}));},listenForCloseButton:function(s,t){q(n.listen(s,'click',function(){k.hide(t);}));},listenForButtons:function(s,t){q(n.listen(s,'click',function(){var v=m.find(s,"^._1ui8"),w=m.find(v,"._3f-c"),x=m.find(v,"._3f-d");k.hide(w);k.show(x);}));var u=m.find(t,"._3f-e");q(n.listen(u,'click',function(){var v=m.find(t,"^._1ui8"),w=m.find(v,"._3f-c");k.hide(t);k.show(w);}));},listenForHideConfirm:function(s,t,u){q(n.listen(s,'click',function(v){setTimeout(function(){var w=j.getContext(s),x=o.getURIBuilder(),y=w&&JSON.parse(w.getAttribute('data-ft'))||{};y.object_id=t;y.reason=u;new h().setMethod('POST').setURI(x.getURI()).setData(y).setRelativeTo(s).send();var z=m.find(s,"^._1ui8"),aa=m.find(s,"^._4-u2");l.remove(z);var ba=m.scry(aa,"._1ui8");if(ba.length===0)l.remove(aa);},i.HIDE_DELAY);}));},listenForUnitHideButton:function(s,t,u){q(n.listen(s,'click',function(v){setTimeout(function(){var w=o.getURIBuilder(),x={object_id:u,unit:true,reason:0};new h().setMethod('POST').setURI(w.getURI()).setData(x).send();l.remove(t);},i.HIDE_DELAY);}));}};f.exports=r;},null);
__d('ChainingActionLink',['CSS','DOM','Event','csx','tidyEvent','BanzaiODS'],function a(b,c,d,e,f,g,h,i,j,k,l,m){if(c.__markCompiled)c.__markCompiled();var n="._4sb9",o="._5g3q",p="._5g3r",q={listenForClick:function(r){var s=i.scry(r,n),t=i.find(r,o),u=i.find(r,p);s.forEach(function(v){l(j.listen(v,'click',function(){t&&h.hide(t);u&&h.show(u);}));});},countSavesAndShares:function(r,s,t){j.listen(r,'click',function(event){m.bumpEntityKey('pubcontent','pubcontent_chaining.article_chaining.save_gk_'+t);});j.listen(s,'click',function(event){m.bumpEntityKey('pubcontent','pubcontent_chaining.article_chaining.share_gk_'+t);});}};f.exports=q;},null);