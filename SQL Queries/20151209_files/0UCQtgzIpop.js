/*!CK:4195900470!*//*1449519871,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["a27eG"]); }

__d('PageGetNotificationConstants',['fbt','keyMirror'],function a(b,c,d,e,f,g,h,i){if(c.__markCompiled)c.__markCompiled();var j={Events:i({CHANGE:null}),Title:{video:h._("Videos"),photo:h._("Photos"),link:h._("Links"),others:h._("Status Updates"),event:h._("Events"),all_posts:h._("All Posts"),none:h._("None")},NewsFeedTitle:{unfollow:h._("Unfollow"),see_first:h._("See First"),follow:h._("Default")},PostSubscriptionType:i({video:null,photo:null,link:null,others:null}),PostSubscriptionTypeArray:['video','photo','link','others'],EventSubscriptionType:i({event:null})};f.exports=j;},null);
__d('PageGetNotificationUtil',['PageGetNotificationConstants'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();var i={subtitleForPageGetNotification:function(j){var k=h.PostSubscriptionTypeArray.map(function(n){return j[n];}),l=k.reduce(function(n,o){return n&&o;},true),m=[];if(l){m.push(h.Title.all_posts);}else h.PostSubscriptionTypeArray.map(function(n){if(j[n])m.push(h.Title[n]);});if(j[h.EventSubscriptionType.event])m.push(h.Title.event);if(m.length!==0)return m.join(', ');return h.Title.none;}};f.exports=i;},null);
__d("XPageUserFanningSettingsStatusController",["XController"],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports=c("XController").create("\/pages\/get_notification\/status\/",{page_id:{type:"String",required:true}});},null);
__d('PageLikeHoverButton',['Arbiter','AsyncRequest','DOM','PageGetNotificationConstants','PageGetNotificationUtil','PageLikeButton','PageLikeConstants','Run','SubscriptionsHandler','XPageUserFanningSettingsStatusController'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q){if(c.__markCompiled)c.__markCompiled();function r(s,t,u,v){'use strict';var w=arguments.length<=4||arguments[4]===undefined?'':arguments[4];this.$PageLikeHoverButton1=v;this.$PageLikeHoverButton2=t;this.$PageLikeHoverButton3=u;this.$PageLikeHoverButton4=w;this.$PageLikeHoverButton5=new p();this.$PageLikeHoverButton5.addSubscriptions(s.subscribe('itemclick',(function(x,y){return this.$PageLikeHoverButton6(y);}).bind(this)),h.subscribe(k.Events.CHANGE,(function(x,y){if(v===y.pageid)this.$PageLikeHoverButton7(y);}).bind(this)),h.subscribe(n.LIKED_SUCCESS,(function(x,y){return this.$PageLikeHoverButton8(y);}).bind(this)),h.subscribe(n.UNLIKED,(function(x,y){return this.$PageLikeHoverButton9(y);}).bind(this)));o.onLeave((function(){return this.cleanUp;}).bind(this));}r.prototype.$PageLikeHoverButton6=function(s){'use strict';if(s.item.getValue()==='Unlike.'+this.$PageLikeHoverButton1)m.doUnlikeAction(s.event,this.$PageLikeHoverButton1,this.$PageLikeHoverButton4,this.$PageLikeHoverButton3);};r.prototype.$PageLikeHoverButton7=function(s){'use strict';if('follow_status' in s){this.$PageLikeHoverButton10(s);this.$PageLikeHoverButton11(s.follow_status);return;}var t=q.getURIBuilder().setString('page_id',this.$PageLikeHoverButton1).getURI();new i(t).setHandler((function(u){this.$PageLikeHoverButton10(u.payload);this.$PageLikeHoverButton11(u.payload.follow_status);}).bind(this)).send();};r.prototype.$PageLikeHoverButton8=function(s){'use strict';if(s.profile_id===this.$PageLikeHoverButton1){if(this.$PageLikeHoverButton2)this.$PageLikeHoverButton2.show();var t=q.getURIBuilder().setString('page_id',this.$PageLikeHoverButton1).getURI();new i(t).setHandler((function(u){this.$PageLikeHoverButton10(u.payload);this.$PageLikeHoverButton11('follow');}).bind(this)).send();}};r.prototype.$PageLikeHoverButton9=function(s){'use strict';if(s.profile_id===this.$PageLikeHoverButton1){if(this.$PageLikeHoverButton2)this.$PageLikeHoverButton2.hide();var t=q.getURIBuilder().setString('page_id',this.$PageLikeHoverButton1).getURI();new i(t).setHandler((function(u){this.$PageLikeHoverButton10(u.payload);this.$PageLikeHoverButton11('unfollow');}).bind(this)).send();}};r.prototype.$PageLikeHoverButton11=function(s){'use strict';if(!this.$PageLikeHoverButton12)this.$PageLikeHoverButton12=document.getElementById('getNotifNewsfeedSubtitle.'+this.$PageLikeHoverButton1);j.setContent(this.$PageLikeHoverButton12,k.NewsFeedTitle[s]);};r.prototype.$PageLikeHoverButton10=function(s){'use strict';if(!this.$PageLikeHoverButton13)this.$PageLikeHoverButton13=document.getElementById('getNotifSubtitle.'+this.$PageLikeHoverButton1);j.setContent(this.$PageLikeHoverButton13,l.subtitleForPageGetNotification(s));};r.prototype.cleanUp=function(){'use strict';this.$PageLikeHoverButton5&&this.$PageLikeHoverButton5.release();this.$PageLikeHoverButton5=null;};f.exports=r;},null);
__d('ReactComposerAudienceActionTypes',['keyMirror'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();f.exports=h({SET_AUDIENCE:null,SET_AUDIENCE_ELEMENT:null,SET_AUDIENCE_INSTANCE:null,SET_PRIVACYX_NULL_DANGEROUS:null});},null);
__d('ReactComposerAudienceStore',['ReactComposerActionStore','ReactComposerAudienceActionTypes','$','DOM','csx','invariant'],function a(b,c,d,e,f,g,h,i,j,k,l,m){if(c.__markCompiled)c.__markCompiled();var n,o;n=babelHelpers.inherits(p,h);o=n&&n.prototype;function p(){'use strict';var q;o.constructor.call(this,function(){return {audience:null,audienceElement:null,audienceInstance:null,legacyAudience:null,privacyxNullDangerous:false};},function(r){switch(r.type){case i.SET_AUDIENCE:q&&q.$ReactComposerAudienceStore1(r);break;case i.SET_AUDIENCE_ELEMENT:q&&q.$ReactComposerAudienceStore2(r);break;case i.SET_AUDIENCE_INSTANCE:q&&q.$ReactComposerAudienceStore3(r);break;case i.SET_PRIVACYX_NULL_DANGEROUS:q&&q.$ReactComposerAudienceStore4(r);break;}});q=this;}p.prototype.getAudience=function(q){'use strict';if(this.getPrivacyxNullDangerous(q))return null;var r=k.scry(j(q),"._5dd8");!(r.length<2)?m(0):undefined;var s=r[0];if(s){var t=k.scry(s,'input[name="privacyx"]');!(t.length<2)?m(0):undefined;if(t.length===1)return t[0].value;}return this.getComposerData(q).audience;};p.prototype.getLegacyAudience=function(q){'use strict';return this.getComposerData(q).legacyAudience;};p.prototype.getAudienceElement=function(q){'use strict';return this.getComposerData(q).audienceElement;};p.prototype.getAudienceInstance=function(q){'use strict';return this.getComposerData(q).audienceInstance;};p.prototype.getPrivacyxNullDangerous=function(q){'use strict';return this.getComposerData(q).privacyxNullDangerous;};p.prototype.$ReactComposerAudienceStore1=function(q){'use strict';var r=this.validateAction(q,'composerID'),s=this.getComposerData(r);s.audience=q.audience;s.legacyAudience=q.legacyAudience;this.emitChange(r);};p.prototype.$ReactComposerAudienceStore2=function(q){'use strict';var r=this.validateAction(q,['composerID','audienceElement']),s=r[0],t=r[1],u=this.getComposerData(s);u.audienceElement=t;this.emitChange(s);};p.prototype.$ReactComposerAudienceStore3=function(q){'use strict';var r=this.validateAction(q,'composerID'),s=this.getComposerData(r);s.audienceInstance=q.audienceInstance?q.audienceInstance.getInstance().getInstance():null;this.emitChange(r);};p.prototype.$ReactComposerAudienceStore4=function(q){'use strict';var r=this.validateAction(q,'composerID'),s=this.getComposerData(r);s.privacyxNullDangerous=q.privacyxNullDangerous;this.emitChange(r);};f.exports=new p();},null);
__d('ReactComposerAudienceActions',['ReactComposerAudienceActionTypes','ReactComposerDispatcher','ReactComposerAudienceStore'],function a(b,c,d,e,f,g,h,i){if(c.__markCompiled)c.__markCompiled();c('ReactComposerAudienceStore');var j={setAudience:function(k,l,m){i.dispatch({composerID:k,type:h.SET_AUDIENCE,audience:l,legacyAudience:m});},setAudienceElement:function(k,l){i.dispatch({composerID:k,type:h.SET_AUDIENCE_ELEMENT,audienceElement:l});},setAudienceInstance:function(k,l){i.dispatch({composerID:k,type:h.SET_AUDIENCE_INSTANCE,audienceInstance:l});},setPrivacyxNullDangerous:function(k,l){i.dispatch({composerID:k,type:h.SET_PRIVACYX_NULL_DANGEROUS,privacyxNullDangerous:l});}};f.exports=j;},null);
__d('ReactComposerAudienceInit',['ReactComposerAudienceActions'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();var i={init:function(j,k){h.setAudienceInstance(j,k.audienceInstance);if(k.privacyx)h.setAudience(j,k.privacyx);}};f.exports=i;},null);
__d('ReactComposerStatusActionType',['keyMirror'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();f.exports=h({SET_EDITOR_STATE:null,SET_HAS_TEXT:null,SET_MENTIONS:null,SET_MENTIONS_SOURCE:null,SET_TYPEAHEAD_REPORTER:null});},null);
__d('ReactComposerStatusStore',['ReactComposerStatusActionType','ReactComposerStoreBase','getMentionsTextForContentState'],function a(b,c,d,e,f,g,h,i,j){if(c.__markCompiled)c.__markCompiled();var k,l;k=babelHelpers.inherits(m,i);l=k&&k.prototype;function m(){'use strict';var n;l.constructor.call(this,function(){return {editorState:null,hasText:false,mentionsSource:null,typeaheadReporter:null,mentions:null};},function(o){switch(o.type){case h.SET_MENTIONS_SOURCE:n&&n.$ReactComposerStatusStore1(o);break;case h.SET_TYPEAHEAD_REPORTER:n&&n.$ReactComposerStatusStore2(o);break;case h.SET_EDITOR_STATE:n&&n.$ReactComposerStatusStore3(o);break;case h.SET_MENTIONS:n&&n.$ReactComposerStatusStore4(o);break;case h.SET_HAS_TEXT:n&&n.$ReactComposerStatusStore5(o);break;}});n=this;}m.prototype.getMentionsSource=function(n){'use strict';return this.getComposerData(n).mentionsSource;};m.prototype.getTypeaheadReporter=function(n){'use strict';return this.getComposerData(n).typeaheadReporter;};m.prototype.getEditorState=function(n){'use strict';return this.getComposerData(n).editorState;};m.prototype.getMentions=function(n){'use strict';return this.getComposerData(n).mentions;};m.prototype.getMessage=function(n){'use strict';var o=this.getEditorState(n);if(!o)return '';var p=o.getCurrentContent();return j(p);};m.prototype.getMessageText=function(n){'use strict';var o=this.getEditorState(n);if(!o)return '';var p=o.getCurrentContent();return p?p.getPlainText():'';};m.prototype.hasText=function(n){'use strict';return this.getComposerData(n).hasText;};m.prototype.$ReactComposerStatusStore1=function(n){'use strict';var o=this.getComposerData(n.composerID);o.mentionsSource=n.mentionsSource;this.emitChange(n.composerID);};m.prototype.$ReactComposerStatusStore2=function(n){'use strict';var o=this.getComposerData(n.composerID);o.typeaheadReporter=n.typeaheadReporter;this.emitChange(n.composerID);};m.prototype.$ReactComposerStatusStore3=function(n){'use strict';var o=this.getComposerData(n.composerID);o.editorState=n.editorState;this.emitChange(n.composerID);};m.prototype.$ReactComposerStatusStore4=function(n){'use strict';var o=this.getComposerData(n.composerID);o.mentions=n.mentions;this.emitChange(n.composerID);};m.prototype.$ReactComposerStatusStore5=function(n){'use strict';var o=this.validateAction(n,['composerID','hasText']),p=o[0],q=o[1],r=this.getComposerData(p);r.hasText=q;this.emitChange(p);};f.exports=new m();},null);