/*!CK:333163036!*//*1449614305,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["ltAKA"]); }

__d("InstanceProxy",[],function a(b,c,d,e,f,g){if(c.__markCompiled)c.__markCompiled();function h(i){"use strict";this.$InstanceProxy1=i;}h.prototype.getInstance=function(){"use strict";return this.$InstanceProxy1;};h.prototype.setInstance=function(i){"use strict";this.$InstanceProxy1=i;};f.exports=h;},null);
__d('CLoggerX',['Banzai','DOM','Event','Keys','Parent','debounce','ge','getOrCreateDOMID'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o){if(c.__markCompiled)c.__markCompiled();var p=10*60*1000,q=k.RETURN,r={},s=function(v){var w=(v.target||v.srcElement).id,x=(v.target||v.srcElement).value.trim().length,y=t.getTracker(w);if(!y)return;if(x>5&&!y.submitted){h.post('censorlogger',{cl_impid:y.impid,clearcounter:y.clearcounter,instrument:y.type,elementid:w,parent_fbid:y.parent_fbid=='unknown'?null:y.parent_fbid,version:"x"},h.VITAL);t.setSubmitted(w,true);}else if(x===0&&y.submitted&&v.which!=q){r[w]=u(w);r[w]();}else if(x>0&&y.submitted)if(r[w])r[w].reset();},t={init:function(){this.trackedElements=this.trackedElements||{};this.feedbackForms=this.feedbackForms||{};},setImpressionID:function(v){this.init();this.impressionID=v;this.clean();},setComposerTargetData:function(v){this.cTargetID=v.targetID||'unknown';this.cTargetFBType=v.targetType||'unknown';},clean:function(){for(var v in this.trackedElements){if(r[v]){r[v].reset();delete r[v];}delete this.trackedElements[v];}},trackComposer:function(v,w,x){this.setComposerTargetData(x);this.startTracking(v,'composer',this.cTargetID,this.cTargetFBType,w);},trackFeedbackForm:function(v,w,x){this.init();this.impressionID=this.impressionID||x;var y,z;y=w?w.targetID||'unknown':'unknown';z=w?w.targetType||'unknown':'unknown';this.feedbackForms[v]={parent_fbid:y,parent_type:z};},trackMentionsInput:function(v,w){this.init();var x,y,z;if(!v)return;x=l.byTag(v,'form');if(!x)return;y=o(x);z=this.feedbackForms[y];if(!z)return;var aa=w||z.parent_fbid,ba=w?416:z.parent_type;this.startTracking(v,'comment',aa,ba,x);},startTracking:function(v,w,x,y,z){this.init();var aa=o(v);if(this.getTracker(aa))return;var ba=o(z);j.listen(v,'keyup',s.bind(this));this.trackedElements[aa]={submitted:false,clearcounter:0,type:w,impid:this.impressionID,parent_fbid:x,parent_type:y,parentElID:ba};this.addJoinTableInfoToForm(z,aa);},getTracker:function(v){return this.trackedElements?this.trackedElements[v]:null;},setSubmitted:function(v,w){if(this.trackedElements[v])this.trackedElements[v].submitted=w;},incrementClearCounter:function(v){var w=this.getTracker(v);if(!w)return;w.clearcounter++;w.submitted=false;var x=i.scry(n(w.parentElID),'input[name="clp"]')[0];if(x)x.value=this.getJSONRepForTrackerID(v);this.trackedElements[v]=w;},addJoinTableInfoToForm:function(v,w){var x=this.getTracker(w);if(!x)return;var y=i.scry(v,'input[name="clp"]')[0];if(!y)i.prependContent(v,i.create('input',{type:'hidden',name:'clp',value:this.getJSONRepForTrackerID(w)}));},getCLParamsForTarget:function(v,w){if(!v)return "";var x=o(v);return this.getJSONRepForTrackerID(x,w);},getJSONRepForTrackerID:function(v,w){var x=this.getTracker(v);if(!x)return "";return JSON.stringify({cl_impid:x.impid,clearcounter:x.clearcounter,elementid:v,version:"x",parent_fbid:w||x.parent_fbid});}},u=function(v){return m(function(){t.incrementClearCounter(v);},p,t);};f.exports=t;},null);
__d('CensorLogger',['Banzai','DOM','Event','Keys','debounce','ge','getOrCreateDOMID'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o=10*60*1000,p=k.RETURN,q=function(t){var u=(t.target||t.srcElement).id,v=(t.target||t.srcElement).value.trim().length,w=r.tracker(u);if(!w)return;if(v>5&&!w.submitted){if(w.type=='comment'&&w.parent_fbid=='unknown'){if(!r.syncTrackerWithForm(u))r.snowliftSync(u);w=r.tracker(u);}h.post('censorlogger',{impid:w.impid,clearcounter:w.clearcounter,instrument:w.type,elementid:u,parent_fbid:w.parent_fbid=='unknown'?null:w.parent_fbid,version:"original"},h.VITAL);r.setSubmitted(u,true);}else if(v===0&&w.submitted&&t.which!=p){r.debouncers[u]=s(u);r.debouncers[u]();}else if(v>0&&w.submitted)if(r.debouncers[u])r.debouncers[u].reset();},r={init:function(t){this.impressionID=t;for(var u in this.trackedElements)if(!m(u))this.stopTracking(u);for(var v in this.unmatchedForms)if(!m(v))delete this.unmatchedForms[v];},trackElement:function(t,u,v){var w,x,y;this.debouncers=this.debouncers||{};this.trackedElements=this.trackedElements||{};this.unmatchedForms=this.unmatchedForms||{};u=u.toLowerCase();if(u=='composer'){w=v?i.find(t,'div.uiMetaComposerMessageBox textarea.input'):i.find(t,'div.uiComposerMessageBox textarea.input');x=i.find(t,'form.attachmentForm');var z=i.scry(t,'input[name="xhpc_targetid"]')[0];if(z)y=z.value;}else if(u=='comment')w=i.find(t,'div.commentBox textarea.textInput');if(w==null)return;var aa=n(w);if(x)this.addJoinTableInfoToForm(x,n(w));j.listen(w,'keyup',q.bind(this));this.trackedElements[aa]={submitted:false,clearcounter:0,type:u,impid:this.impressionID,parent_fbid:y||'unknown',formID:x?n(x):null};if(u=='comment')this.syncTrackerWithForm(aa);},registerForm:function(t,u){this.unmatchedForms=this.unmatchedForms||{};this.unmatchedForms[t]=u;},syncTrackerWithForm:function(t){for(var u in this.unmatchedForms){var v=m(u);if(v){var w=i.scry(v,'div.commentBox textarea.textInput')[0];if(w){var x=n(w);if(x&&x==t){this.trackedElements[t].parent_fbid=this.unmatchedForms[u];this.trackedElements[t].formID=u;this.addJoinTableInfoToForm(v,t);delete this.unmatchedForms[u];return true;}}}}return false;},snowliftSync:function(t){var u,v=m(t);if(v&&(u=i.scry(v,'^.fbPhotosSnowboxFeedbackInput')[0])){var w=i.find(u,'input[name="feedback_params"]'),x=JSON.parse(w.value).target_fbid;this.trackedElements[t].parent_fbid=x;this.trackedElements[t].formID=u.id;this.addJoinTableInfoToForm(u,t);return true;}return false;},stopTracking:function(t){delete this.trackedElements[t];if(this.debouncers[t]){this.debouncers[t].reset();delete this.debouncers[t];}},tracker:function(t){return this.trackedElements[t];},getSubmitted:function(t){return this.trackedElements[t]?this.trackedElements[t].submitted:false;},setSubmitted:function(t,u){if(this.trackedElements[t])this.trackedElements[t].submitted=u;},incrementClearCounter:function(t){if(!this.tracker(t))return;this.trackedElements[t].clearcounter++;this.trackedElements[t].submitted=false;var u=i.scry(m(this.trackedElements[t].formID),'input[name="clp"]')[0];if(u)u.value=JSON.stringify({censorlogger_impid:this.trackedElements[t].impid,clearcounter:this.trackedElements[t].clearcounter,element_id:t});},addJoinTableInfoToForm:function(t,u){i.prependContent(t,i.create('input',{type:'hidden',name:'clp',value:JSON.stringify({censorlogger_impid:this.impressionID,clearcounter:0,element_id:u,version:"original"})}));}},s=function(t){return l(function(){r.incrementClearCounter(t);},o,r);};f.exports=r;},null);
__d('legacy:ScrollAwareDOM',['ScrollAwareDOM'],function a(b,c,d,e){if(c.__markCompiled)c.__markCompiled();b.ScrollAwareDOM=c('ScrollAwareDOM');},3);
__d('FeedTrackingAsync',['Arbiter','collectDataAttributes'],function a(b,c,d,e,f,g,h,i){if(c.__markCompiled)c.__markCompiled();function j(){h.subscribe('AsyncRequest/send',function(k,l){var m=l.request,n=m.getRelativeTo();if(n){var o=m.getData(),p=i(n,['ft']);if(Object.keys(p.ft).length)Object.assign(o,p);}});}f.exports={init:j};},null);
__d('LitestandStream',['CSS','DOMQuery','LitestandStoryInsertionStatus','ViewportBounds','cx','csx','ge','getElementPosition','getOrCreateDOMID','nullthrows'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q){if(c.__markCompiled)c.__markCompiled();var r,s,t={init:function(u,v,w){r=w;s=u;},getStoriesSelector:function(){return "._5jmm";},getStreamRoot:function(){return s;},getSectionID:function(){return r;},isStory:function(u){return h.hasClass(u,"_5jmm");},canInsertNewerStories:function(){if(k.getTop()>o(t.getStreamRoot()).y)return false;return j.canInsert();},getFeedStreamID:function(){return parseInt(q(s).id.split('feed_stream_')[1],16)%1e+08;},setAriaLabelledBy:function(u){var v=n(u),w;if(v&&this.isStory(v)){if(v.getAttribute('aria-labelledby'))return;w=[].concat(i.scry(v,"._5pbw")).concat([".timestampContent",".uiStreamSponsoredLink","._5pbx"].map(function(x){return i.scry(v,x)[0];}).filter(function(x){return !!x;}));if(w.length>0)v.setAttribute('aria-labelledby',w.map(function(x){return p(x);}).join(' '));}}};f.exports=t;},null);
__d('OnVisible',['Arbiter','DOM','Event','Parent','Run','Vector','ViewportBounds','coalesce','queryThenMutateDOM'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p){if(c.__markCompiled)c.__markCompiled();var q=[],r,s=0,t=[],u,v,w,x,y;function z(){q.forEach(function(fa){fa.remove();});if(v){v.remove();u.remove();r.unsubscribe();v=u=r=null;}s=0;q.length=0;}function aa(){if(!q.length){z();return;}t.length=0;w=m.getScrollPosition().y;x=m.getViewportDimensions().y;y=n.getTop();for(var fa=0;fa<q.length;++fa){var ga=q[fa];if(isNaN(ga.elementHeight))t.push(fa);ga.elementHeight=m.getElementDimensions(ga.element).y;ga.elementPos=m.getElementPosition(ga.element);ga.hidden=k.byClass(ga.element,'hidden_elem');if(ga.scrollArea){ga.scrollAreaHeight=m.getElementDimensions(ga.scrollArea).y;ga.scrollAreaY=m.getElementPosition(ga.scrollArea).y;}}s=fa;}function ba(){for(var fa=Math.min(q.length,s)-1;fa>=0;--fa){var ga=q[fa];if(!ga.elementPos||ga.removed){q.splice(fa,1);continue;}if(ga.hidden)continue;var ha=w+x+ga.buffer,ia=false;if(ha>ga.elementPos.y){var ja=w+y-ga.buffer,ka=w+y+x+ga.buffer,la=ga.elementPos.y+ga.elementHeight,ma=!ga.strict||ja<ga.elementPos.y&&ka>la;ia=ma;if(ia&&ga.scrollArea){var na=ga.scrollAreaY+ga.scrollAreaHeight+ga.buffer;ia=ga.elementPos.y>ga.scrollAreaY-ga.buffer&&ga.elementPos.y<na;}}if(ga.inverse?!ia:ia){ga.remove();ga.handler(t.indexOf(fa)!==-1);}}}function ca(){da();if(q.length)return;v=j.listen(window,'scroll',da);u=j.listen(window,'resize',da);r=h.subscribe('dom-scroll',da);}function da(){p(aa,ba,'OnVisible/positionCheck');}function ea(fa,ga,ha,ia,ja,ka){'use strict';this.element=fa;this.handler=ga;this.strict=ha;this.buffer=o(ia,300);this.inverse=o(ja,false);this.scrollArea=ka||null;if(this.scrollArea)this.scrollAreaListener=this.$OnVisible1();if(q.length===0)l.onLeave(z);ca();q.push(this);}ea.prototype.remove=function(){'use strict';if(this.removed)return;this.removed=true;if(this.scrollAreaListener)this.scrollAreaListener.remove();};ea.prototype.reset=function(){'use strict';this.elementHeight=null;this.removed=false;if(this.scrollArea)this.scrollAreaListener=this.$OnVisible1();q.indexOf(this)===-1&&q.push(this);ca();};ea.prototype.setBuffer=function(fa){'use strict';this.buffer=fa;da();};ea.prototype.checkBuffer=function(){'use strict';da();};ea.prototype.getElement=function(){'use strict';return this.element;};ea.prototype.$OnVisible1=function(){'use strict';return j.listen(i.find(this.scrollArea,'.uiScrollableAreaWrap'),'scroll',this.checkBuffer);};Object.assign(ea,{checkBuffer:da});f.exports=ea;},null);
__d('PopoverAsyncMenu',['Bootloader','Event','PopoverMenu','setImmediate'],function a(b,c,d,e,f,g,h,i,j,k){if(c.__markCompiled)c.__markCompiled();var l,m,n={},o=0;l=babelHelpers.inherits(p,j);m=l&&l.prototype;function p(q,r,s,t,u,v){'use strict';m.constructor.call(this,q,r,null,u);this._endpoint=t;this._endpointData=v||{};this._loadingMenu=s;this._instanceId=o++;n[this._instanceId]=this;this._mouseoverListener=i.listen(r,'mouseover',this.fetchMenu.bind(this));}p.prototype._onLayerInit=function(){'use strict';if(!this._menu&&this._loadingMenu)this.setMenu(this._loadingMenu);this._popover.getLayer().subscribe('key',this._handleKeyEvent.bind(this));k((function(){return this.fetchMenu();}).bind(this));};p.prototype.fetchMenu=function(){'use strict';if(this._fetched)return;h.loadModules(["AsyncRequest"],(function(q){new q().setURI(this._endpoint).setData(Object.assign({pmid:this._instanceId},this._endpointData)).send();}).bind(this));this._fetched=true;if(this._mouseoverListener){this._mouseoverListener.remove();this._mouseoverListener=null;}};p.setMenu=function(q,r){'use strict';n[q].setMenu(r);};p.getInstance=function(q){'use strict';return n[q];};f.exports=p;},null);
__d('ScrollingPager',['Arbiter','CSS','DOM','OnVisible','UIPagelet','$','ge'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o={};function p(q,r,s,t){'use strict';this.scroll_loader_id=q;this.pagelet_src=r;this.data=s;this.options=t||{};if(this.options.target_id){this.target_id=this.options.target_id;this.options.append=true;}else this.target_id=q;this.scroll_area_id=this.options.scroll_area_id;this.handler=null;}p.prototype.setBuffer=function(q){'use strict';this.options.buffer=q;this.onvisible&&this.onvisible.setBuffer(q);};p.prototype.getBuffer=function(){'use strict';return this.options.buffer;};p.prototype.register=function(){'use strict';this.onvisible=new k(m(this.scroll_loader_id),this.getHandler(),false,this.options.buffer,false,n(this.scroll_area_id));o[this.scroll_loader_id]=this;h.inform(p.REGISTERED,{id:this.scroll_loader_id});};p.prototype.getInstance=function(q){'use strict';return o[q];};p.prototype.getHandler=function(){'use strict';if(this.handler)return this.handler;function q(r){var s=n(this.scroll_loader_id);if(!s){this.onvisible.remove();return;}i.addClass(s.firstChild,'async_saving');var t=this.options.handler,u=this.options.force_remove_pager&&this.scroll_loader_id!==this.target_id;this.options.handler=function(){h.inform('ScrollingPager/loadingComplete');t&&t.apply(null,arguments);if(u)j.remove(s);};if(r)this.data.pager_fired_on_init=true;l.loadFromEndpoint(this.pagelet_src,this.target_id,this.data,this.options);}return q.bind(this);};p.prototype.setHandler=function(q){'use strict';this.handler=q;};p.prototype.removeOnVisible=function(){'use strict';this.onvisible.remove();};p.prototype.checkBuffer=function(){'use strict';this.onvisible&&this.onvisible.checkBuffer();};p.getInstance=function(q){'use strict';return o[q];};Object.assign(p,{REGISTERED:'ScrollingPager/registered'});f.exports=p;},null);
__d('legacy:ui-scrolling-pager-js',['ScrollingPager'],function a(b,c,d,e){if(c.__markCompiled)c.__markCompiled();b.ScrollingPager=c('ScrollingPager');},3);
__d('FbFeedCommentUFIScroller',['Arbiter','DOMScroll','UFIUIEvents','containsNode','ge'],function a(b,c,d,e,f,g,h,i,j,k,l){if(c.__markCompiled)c.__markCompiled();h.subscribe(j.CommentFocus,function(m,n){var o=n.element,p=l('content');if(p&&k(p,o))i.ensureVisible(o,null,60,250);});f.exports={};},null);
__d('PopoverLoadingMenu',['BehaviorsMixin','DOM','PopoverMenuInterface','cx','joinClasses'],function a(b,c,d,e,f,g,h,i,j,k,l){if(c.__markCompiled)c.__markCompiled();var m,n;m=babelHelpers.inherits(o,j);n=m&&m.prototype;function o(p){'use strict';n.constructor.call(this);this._config=p||{};this._theme=p.theme||{};}o.prototype.getRoot=function(){'use strict';if(!this._root){this._root=i.create('div',{className:l("_54nq",this._config.className,this._theme.className)},i.create('div',{className:"_54ng"},i.create('div',{className:"_54nf _54af"},i.create('span',{className:"_54ag"}))));if(this._config.behaviors)this.enableBehaviors(this._config.behaviors);}return this._root;};Object.assign(o.prototype,h,{_root:null});f.exports=o;},null);