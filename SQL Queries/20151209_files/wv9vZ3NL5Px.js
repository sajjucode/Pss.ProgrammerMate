/*!CK:2183349523!*//*1448853182,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["6duHX"]); }

__d("MercurySupportedShareType",[],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports={FB_PHOTO:2,FB_ALBUM:3,FB_VIDEO:11,FB_EVENT:7,FB_SONG:28,FB_MUSIC_ALBUM:30,FB_PLAYLIST:31,FB_MUSICIAN:35,FB_RADIO_STATION:33,EXTERNAL:100,FB_TEMPLATE:300,FB_SOCIAL_REPORT_PHOTO:48,FB_COUPON:32,FB_SHARE:99,FB_HC_QUESTION:55,FB_HC_ANSWER:56,FB_SOCIAL_RESOLUTION:60,FB_STATUS:22,FB_BROWSE_QUERY:47,FB_SYNC_REQUEST:61,FB_OPEN_GRAPH:44,FB_ORION:64,FB_GENERIC_SHAREABLE:69};},null);
__d("MessagingFilteringType",[],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports={LEGACY:"legacy",MODERATE:"moderate",STRICT:"strict"};},null);
__d("PUWApplications",[],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports={WEB_SIMPLE:"web_simple",WEB_FLASH:"web_flash",WEB_HTML5:"web_html5",WEB_COMPOSER:"web_composer",WEB_ARCHIVE:"web_archive",WEB_MESSENGER:"web_messenger",WEB_OMNIPICKER:"web_omnipicker",WEB_MUSE_OMNIPICKER:"web_muse_omnipicker",WEB_SAY_THANKS:"web_say_thanks",WEB_GOODWILL_CAMPAIGN_OMNIPICKER:"web_goodwill_campaign_omnipicker",WEB_PRODUCT_PHOTO_OMNIPICKER:"web_product_photo_omnipicker",WEB_PAGES_MESSENGER:"web_pages_messenger",WEB_M_ZERO:"web_m_zero",WEB_M_BASIC:"web_m_basic",WEB_M_TOUCH:"web_m_touch",WEB_REACT_COMPOSER:"web_react_composer",MOBILE_FB4IOS:"mobile_fb4ios",MOBILE_FB4IOS_SNAP:"mobile_fb4ios_snap",MOBILE_FB4A:"mobile_fb4a",MOBILE_PMA_ANDROID:"mobile_pma_android",MOBILE_PMA_IOS:"mobile_pma_ios",THIRD_PARTY:"third_party"};},null);
__d("PUWSteps",[],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports={CLIENT_FLOW_BEGIN:"client_flow_begin",CLIENT_SELECT_BEGIN:"client_select_begin",CLIENT_SELECT_SUCCESS:"client_select_success",CLIENT_SELECT_CANCEL:"client_select_cancel",CLIENT_SELECT_FAIL:"client_select_fail",CLIENT_FLOW_POST:"client_flow_post",CLIENT_TRANSFER_BATCH_BEGIN:"client_transfer_batch_begin",CLIENT_UPLOAD_BEGIN:"client_upload_begin",CLIENT_ATTACH_PHOTO:"client_attach_photo",CLIENT_PROCESS_BEGIN:"client_process_begin",CLIENT_PROCESS_SUCCESS:"client_process_success",CLIENT_PROCESS_CANCEL:"client_process_cancel",CLIENT_PROCESS_SKIP:"client_process_skip",CLIENT_PROCESS_FAIL:"client_process_fail",CLIENT_PROCESS_UNAVAILABLE:"client_process_unavailable",CLIENT_TRANSFER_ENQUEUE:"client_transfer_enqueue",CLIENT_TRANSFER_BEGIN:"client_transfer_begin",CLIENT_TRANSFER_SUCCESS:"client_transfer_success",CLIENT_TRANSFER_CANCEL:"client_transfer_cancel",CLIENT_TRANSFER_FAIL:"client_transfer_fail",CLIENT_TRANSFER_MANUAL_RETRY:"client_transfer_manual_retry",CLIENT_UPLOAD_SUCCESS:"client_upload_success",CLIENT_UPLOAD_FAIL:"client_upload_fail",CLIENT_UPLOAD_CANCEL:"client_upload_cancel",CLIENT_UPLOAD_REMOVE:"client_upload_remove",CLIENT_FACEREC_BEGIN:"client_facerec_begin",CLIENT_FACEREC_SUCCESS:"client_facerec_success",CLIENT_FACEREC_FAIL:"client_facerec_fail",CLIENT_PHOTO_PREVIEW_OPEN:"client_photo_preview_open",CLIENT_PHOTO_PREVIEW_CLOSE:"client_photo_preview_close",CLIENT_TRANSFER_BATCH_SUCCESS:"client_transfer_batch_success",CLIENT_TRANSFER_BATCH_CANCEL:"client_transfer_batch_cancel",CLIENT_TRANSFER_BATCH_FAIL:"client_transfer_batch_fail",CLIENT_PUBLISH_ENQUEUE:"client_publish_enqueue",CLIENT_PUBLISH_BEGIN:"client_publish_begin",CLIENT_PUBLISH_SUCCESS:"client_publish_success",CLIENT_PUBLISH_FAIL:"client_publish_fail",CLIENT_ATTEMPT_FAIL:"client_attempt_fail",CLIENT_FLOW_SUCCESS:"client_flow_success",CLIENT_FLOW_FATAL:"client_flow_fatal",CLIENT_FLOW_GIVEUP:"client_flow_giveup",CLIENT_FLOW_CANCEL:"client_flow_cancel",CLIENT_FLOW_FAIL:"client_flow_fail",CLIENT_FLOW_INCOMPLETE:"client_flow_incomplete",CLIENT_ATTEMPT_INCOMPLETE:"client_attempt_incomplete",CLIENT_FLOW_RETRY:"client_flow_retry",CLIENT_ATTEMPT_RETRY:"client_attempt_retry",CLIENT_DIAGNOSTIC:"client_diagnostic",CLIENT_QUALITY_SWITCH:"client_quality_switch",CLIENT_CANCEL_SURVEY:"client_cancel_survey",CLIENT_PHOTO_EDIT_BEGIN:"client_photo_edit_begin",CLIENT_PHOTO_EDIT_SUCCESS:"client_photo_edit_success",SERVER_UPLOAD_BEGIN:"server_upload_begin",SERVER_UPLOAD_SUCCESS:"server_upload_success",SERVER_UPLOAD_FAIL:"server_upload_fail",SERVER_PUBLISH_BEGIN:"server_publish_begin",SERVER_PUBLISH_SUCCESS:"server_publish_success",SERVER_PUBLISH_FAIL:"server_publish_fail",SERVER_RECEIVER_BEGIN:"server_receiver_begin",SERVER_RECEIVER_PUBLISH_BEGIN:"server_receiver_publish_begin",SERVER_SENTRY_RESTRICTION:"server_sentry_restriction"};},null);
__d('ReactAbstractContextualDialog',['ContextualDialog','ContextualDialogArrow','LayerAutoFocus','LayerHideOnEscape','LayerRefocusOnHide','React','ReactDOM'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o=m.PropTypes,p={createSpec:function(q){return {displayName:q.displayName,propTypes:{position:o.oneOf(['above','below','left','right']),alignment:o.oneOf(['left','center','right']),offsetX:o.number,offsetY:o.number,width:o.number,autoFocus:o.bool,focusContextOnHide:o.bool,arrowBehavior:o.func,behaviors:o.object,shown:o.bool,context:o.object,contextRef:o.func,hoverContext:o.object,hoverContextRef:o.func,hoverShowDelay:o.number,hoverHideDelay:o.number,hideOnEscape:o.bool,onBeforeHide:o.func,onToggle:o.func,hasActionableContext:o.bool},immutableProps:{modal:null},createLayer:function(r){var s=this.props.context||n.findDOMNode(this.props.contextRef()),t=this.props.hoverContext||this.props.hoverContextRef&&n.findDOMNode(this.props.hoverContextRef()),u=babelHelpers._extends({context:s,hoverContext:t,hoverShowDelay:this.props.hoverShowDelay,hoverHideDelay:this.props.hoverHideDelay,position:this.props.position,alignment:this.props.alignment,offsetX:this.props.offsetX,offsetY:this.props.offsetY,width:this.props.width,shouldSetARIAProperties:!this.props.hasActionableContext,arrowBehavior:this.props.arrowBehavior||i,addedBehaviors:this.enumerateBehaviors(this.props.behaviors)},q||{}),v=new h(u,r);if(this.props.contextBounds)v.setContextWithBounds(s,this.props.contextBounds);if(this.props.autoFocus!==false)v.enableBehavior(j);if(this.props.hideOnEscape===true)v.enableBehavior(k);if(this.props.focusContextOnHide===false)v.disableBehavior(l);if(this.props.onBeforeHide)v.subscribe('beforehide',this.props.onBeforeHide);v.conditionShow(this.props.shown);return v;},receiveProps:function(r,s){this.updateBehaviors(s.behaviors,r.behaviors);var t=r.context||r.contextRef&&n.findDOMNode(r.contextRef());if(t)if(r.contextBounds){this.layer.setContextWithBounds(t,r.contextBounds);}else this.layer.setContext(t);this.layer.setPosition(r.position).setAlignment(r.alignment).setOffsetX(r.offsetX).setOffsetY(r.offsetY).setWidth(r.width).conditionShow(r.shown);}};}};f.exports=p;},null);
__d('AbstractBadge.react',['React','cx','invariant','joinClasses'],function a(b,c,d,e,f,g,h,i,j,k){if(c.__markCompiled)c.__markCompiled();var l=h.PropTypes;function m(o){return parseInt(o,10)===o;}var n=h.createClass({displayName:'AbstractBadge',propTypes:{count:l.number.isRequired,maxcount:l.number},getDefaultProps:function(){return {maxcount:20};},render:function(){var o=this.props.count,p=this.props.maxcount;!m(o)?j(0):undefined;!m(p)?j(0):undefined;var q="_51lp"+(o>p?' '+"_51lr":'')+(o===0?' '+"hidden_elem":'');return (h.createElement('span',babelHelpers._extends({},this.props,{className:k(this.props.className,q)}),o>p?p+'+':o));}});f.exports=n;},null);
__d('XUIBadge.react',['React','AbstractBadge.react','cx','joinClasses'],function a(b,c,d,e,f,g,h,i,j,k){if(c.__markCompiled)c.__markCompiled();var l=h.PropTypes,m=h.createClass({displayName:'XUIBadge',propTypes:{type:l.oneOf(['regular','special'])},getDefaultProps:function(){return {type:'regular'};},render:function(){var n=this.props.type,o="_5ugh"+(n==='regular'?' '+"_5ugf":'')+(n==='special'?' '+"_5ugg":'');return (h.createElement(i,babelHelpers._extends({},this.props,{className:k(this.props.className,o),type:null})));}});f.exports=m;},null);
__d('HasLayerContextMixin',['ReactDOM'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();var i={getContextNode:function(){var j=this.props.context;if(this.props.contextRef){var k=this.props.contextRef();j=k&&h.findDOMNode(k);}return j;}};f.exports=i;},null);
__d('XUIContextualDialogBody.react',['React'],function a(b,c,d,e,f,g,h){if(c.__markCompiled)c.__markCompiled();var i=h.createClass({displayName:'XUIContextualDialogBody',render:function(){return (h.createElement('div',{className:this.props.className},this.props.children));}});f.exports=i;},null);
__d('XUIContextualDialogFooter.react',['React','XUIOverlayFooter.react','cx'],function a(b,c,d,e,f,g,h,i,j){if(c.__markCompiled)c.__markCompiled();var k=h.createClass({displayName:'XUIContextualDialogFooter',render:function(){return (h.createElement(i,{className:"_572u"},this.props.children));}});f.exports=k;},null);
__d('XUIContextualDialogTitle.react',['React','cx','joinClasses'],function a(b,c,d,e,f,g,h,i,j){if(c.__markCompiled)c.__markCompiled();var k=h.PropTypes,l=h.createClass({displayName:'XUIContextualDialogTitle',propTypes:{use:k.oneOf(['primary','secondary'])},getDefaultProps:function(){return {use:'primary'};},render:function(){var m=this.props.use,n=j("_47lu"+(m==='primary'?' '+"_47lv":'')+(m==='secondary'?' '+"_47mc":''),this.props.className);return (h.createElement('h3',{className:n},this.props.children));}});f.exports=l;},null);
__d('XUIContextualDialog.react',['HasLayerContextMixin','ContextualDialogXUITheme','React','ReactAbstractContextualDialog','ReactLayer','XUIContextualDialogBody.react','XUIContextualDialogFooter.react','XUIContextualDialogTitle.react','cx'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p){if(c.__markCompiled)c.__markCompiled();var q=j.PropTypes,r=l.createClass(k.createSpec({displayName:'ReactXUIContextualDialog',theme:i})),s=j.createClass({displayName:'XUIContextualDialog',mixins:[h],propTypes:{position:q.oneOf(['above','below','left','right']),alignment:q.oneOf(['left','center','right']),offsetX:q.number,offsetY:q.number,width:q.number,autoFocus:q.bool,arrowBehavior:q.func,behaviors:q.object,shown:q.bool,context:q.object,contextRef:q.func,hoverContext:q.object,hoverContextRef:q.func,hoverShowDelay:q.number,hoverHideDelay:q.number,hideOnEscape:q.bool,onToggle:q.func,hasActionableContext:q.bool},getDefaultProps:function(){return {hasActionableContext:false,hideOnEscape:true};},_getDialogBody:function(){return this._getChildOfType(m);},_getDialogTitle:function(){return this._getChildOfType(o);},_getDialogFooter:function(){return this._getChildOfType(n);},_getChildOfType:function(t){var u=null;j.Children.forEach(this.props.children,function(v){if(!u&&v.type===t)u=v;});return u;},updatePosition:function(){var t=this.refs.dialog;if(t)t.layer.updatePosition();},render:function(){var t=this.props.children,u=this._getDialogBody();if(u)t=j.createElement('div',{className:"_53iv"},this._getDialogTitle(),u);return (j.createElement(r,babelHelpers._extends({},this.props,{ref:'dialog',context:this.getContextNode()}),t,u?this._getDialogFooter():null));}});s.WIDTH={NORMAL:312,WIDE:400};f.exports=s;},null);
__d('PhotosUploadWaterfallXMixin',['AsyncSignal','Banzai','Map','PhotosUploadWaterfallXConfig','Set','invariant','randomInt'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o=new j();function p(r,s){var t={};r.client_time=Math.round(Date.now()/1000);if(k.retryBanzai){t.retry=true;r.nonce=n(4294967296);}i.post(k.banzaiRoute,r,t);if(s)setTimeout(s,0);}function q(r,s){if(k.useBanzai){p(r,s);}else{var t=new h(k.loggingEndpoint,{data:JSON.stringify(r)}).setHandler(s);if(k.timeout)t.setTimeout(10*1000);t.send();}}f.exports={logStep:function(r,s,t){var u=this.getWaterfallID&&this.getWaterfallID(),v=this.getWaterfallAppName&&this.getWaterfallAppName();if(!u||!v)return;q(babelHelpers._extends({step:r,qn:u,uploader:v,ref:this.getWaterfallSource&&this.getWaterfallSource()},s),t);},logPUWStep:function(r,s,t,u,v,w,x){if(w&&w.logOncePerSession){if(!o.has(s))o.set(s,new l());if(o.get(s).has(r))return;o.get(s).add(r);}q(Object.assign({step:r,qn:s,uploader:t,ref:u},v),x);}};},null);
__d('DOMClone',[],function a(b,c,d,e,f,g){if(c.__markCompiled)c.__markCompiled();var h={shallowClone:function(j){return i(j,false);},deepClone:function(j){return i(j,true);}};function i(j,k){var l=j.cloneNode(k);if(typeof l.__FB_TOKEN!=='undefined')delete l.__FB_TOKEN;return l;}f.exports=h;},null);
__d('FileInput',['ArbiterMixin','DOM','DOMClone','Event','Focus','Keys','UserAgent_DEPRECATED','cx','mixin'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p){if(c.__markCompiled)c.__markCompiled();var q,r,s=n.ie();q=babelHelpers.inherits(t,p(h));r=q&&q.prototype;function t(u,v,w){'use strict';r.constructor.call(this);this.container=u;this.control=v;var x=i.scry(this.container,'a')[0];x&&x.removeAttribute('href');var y=i.create('div',{className:"_3jk"},w);i.appendContent(this.control,y);this._boundHandleChange=this._handleChange.bind(this);if(s)this._boundHandleIEKeyDown=this._handleIEKeyDown.bind(this);this._setInputElement(w);}t.prototype.getValue=function(){'use strict';return this.input.value;};t.prototype.getInput=function(){'use strict';return this.input;};t.prototype.getContainer=function(){'use strict';return this.container;};t.prototype.getControl=function(){'use strict';return this.control;};t.prototype.clear=function(){'use strict';if(s){var u=j.deepClone(this.input);i.replace(this.input,u);this._setInputElement(u);}else this.input.value='';};t.prototype.destroy=function(){'use strict';this._focus.remove();this._focus=null;this._listener.remove();this._listener=null;if(s){this._IEKeyDownListener.remove();this._IEKeyDownListener=null;}this.container=null;this.control=null;this.input=null;};t.prototype._setInputElement=function(u){'use strict';this.input=u;this._focus&&this._focus.remove();this._focus=l.relocate(u,this.control);this._listener&&this._listener.remove();this._listener=k.listen(u,'change',this._boundHandleChange);if(s){this._IEKeyDownListener&&this._IEKeyDownListener.remove();this._IEKeyDownListener=k.listen(u,'keydown',this._boundHandleIEKeyDown);}};t.prototype._handleChange=function(event){'use strict';this.inform('change',event);var u=this.input.form;if(u&&s<9)k.fire(u,'change',event);};t.prototype._handleIEKeyDown=function(event){'use strict';if(event.keyCode===m.RETURN){event.preventDefault();var u=document.createEvent('MouseEvents');u.initEvent('click',true,true);this.input.dispatchEvent(u);}};f.exports=t;},null);
__d("PhotosUploadID",[],function a(b,c,d,e,f,g){if(c.__markCompiled)c.__markCompiled();var h=1024,i={getNewID:function(){return (h++).toString();}};f.exports=i;},null);
__d("XPhotosWaterfallBatchLoggingController",["XController"],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports=c("XController").create("\/photos\/logging\/waterfall\/batch\/",{});},null);
__d('PhotosUploadWaterfall',['AsyncRequest','AsyncSignal','Banzai','PhotosUploadWaterfallXConfig','XPhotosWaterfallBatchLoggingController','emptyFunction','randomInt','throttle'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o){if(c.__markCompiled)c.__markCompiled();var p=[],q={APP_FLASH:'flash_pro',APP_SIMPLE:'simple',APP_ARCHIVE:'archive',APP_COMPOSER:'composer',APP_MESSENGER:'messenger',APP_HTML5:'html5',APP_CHAT:'chat',INSTALL_CANCEL:1,INSTALL_INSTALL:2,INSTALL_UPDATE:3,INSTALL_REINSTALL:4,INSTALL_PERMA_CANCEL:5,INSTALL_SILENT_SKIP:6,INSTALL_DOWNLOAD:7,CERROR_RESIZING_FAILED:6,CERROR_MARKER_EXTRACTION_FAILED:9,BEGIN:1,UPLOAD_START:4,ALL_UPLOADS_DONE:6,CLIENT_ERROR:7,RECOVERABLE_CLIENT_ERROR:12,IMAGES_SELECTED:9,UPGRADE_REQUIRED:11,VERSION:15,SELECT_START:18,SELECT_CANCELED:19,CANCEL:22,CANCEL_DURING_UPLOAD:83,ONE_RESIZING_START:2,ONE_UPLOAD_START:10,ONE_UPLOAD_DONE:29,ONE_RESIZING_DONE:34,PROGRESS_BAR_STOPPED:44,MISSED_BEAT:45,HEART_ATTACK:46,PUBLISH_SENT:99,PUBLISH_START:100,PUBLISH_SUCCESS:101,PUBLISH_FAILURE:102,CLUSTERING_START:103,CLUSTERING_SUCCESS:104,CLUSTERING_FAILURE:105,POST_BUTTON_CLICKED:110,POST_BUTTON_ERROR:111,PHOTO_DELETED:114,PUBLISH_CLIENT_SUCCESS:115,PHOTO_ROTATED:117,SAVE_DRAFT_BUTTON_CLICKED:123,RECOVERY_START_ON_CLIENT:124,CHANGE_PHOTO_QUALITY_SETTING:126,TAG_ADDED:127,TAG_REMOVED:128,TAB_BUTTON_CLICKED:129,EDITABLE_PHOTO_FETCH_START:106,EDITABLE_PHOTO_FETCH_SUCCESS:107,EDITABLE_PHOTO_FETCH_FAILURE:108,EDITABLE_PHOTO_FETCH_DELAY:116,CANCEL_INDIVIDUAL_UPLOAD:109,MISSING_OVERLAY_NODE:118,PUBLISH_RETRY_FAILURE:119,MISSING_UPLOAD_STATE:120,SESSION_POSTED:72,POST_PUBLISHED:80,ONE_UPLOAD_CANCELED:81,ONE_UPLOAD_CANCELED_DURING_UPLOAD:82,RESIZER_AVAILABLE:20,OVERLAY_FIRST:61,ASYNC_AVAILABLE:63,FALLBACK_TO_FLASH:13,FALLBACK_TO_HTML5:130,RETRY_UPLOAD:17,TAGGED_ALL_FACES:14,VAULT_IMAGES_SELECTED:62,VAULT_CREATE_POST_CANCEL:65,VAULT_SEND_IN_MESSAGE_CLICKED:66,VAULT_DELETE_CANCEL:68,VAULT_ADD_TO_ALBUM_CANCEL:74,VAULT_SHARE_IN_AN_ALBUM_CLICKED:76,VAULT_SHARE_OWN_TIMELINE_CLICKED:77,VAULT_SHARE_FRIENDS_TIMELINE_CLICKED:78,VAULT_SHARE_IN_A_GROUP_CLICKED:79,VAULT_SYNCED_PAGED_LINK_CLICKED:84,VAULTBOX:'vaultbox',GRID:'grid',SPOTLIGHT_VAULT_VIEWER:'spotlight_vault_viewer',REF_VAULT_NOTIFICATION:'vault_notification',_checkRequiredFields:function(s){},sendBanzai:function(s,t){this._checkRequiredFields(s);var u={};s.scuba_ints=s.scuba_ints||{};s.scuba_ints.client_time=Math.round(Date.now()/1000);if(k.retryBanzai){u.retry=true;s.scuba_ints.nonce=n(4294967296);}j.post(k.deprecatedBanzaiRoute,s,u);if(t)setTimeout(t,0);},sendSignal:function(s,t){this._checkRequiredFields(s);if(k.useBanzai){this.sendBanzai(s,t);}else if(k.reduceLoggingRequests){this.queueLog(s,t);}else{var u=new i('/ajax/photos/waterfall.php',{data:JSON.stringify(s)}).setHandler(t);if(k.timeout)u.setTimeout(10*1000);u.send();}},queueLog:function(s,t){p.push(s);if(!!t){this.flushQueue(t);}else r();},flushQueue:function(s){var t=JSON.stringify(p);p=[];var u=l.getURIBuilder().getURI();new h().setURI(u).setData({logs:t}).setFinallyHandler(s||m).setTimeoutHandler(10*1000,s||m).send();}},r=o(q.flushQueue,k.batchInterval*1000);f.exports=q;},null);