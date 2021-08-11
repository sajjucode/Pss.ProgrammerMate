/*!CK:2880280472!*//*1447097149,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["l\/+Am"]); }

__d('ChatTabOfficeStatus',['fbt','formatDate','CSS'],function a(b,c,d,e,f,g,h,i,j){'use strict';if(c.__markCompiled)c.__markCompiled();var k=1,l=2,m=3,n={update:function(o,p){if(!o||!p||!p.officeStatus)return;this._updateIcon(o,p);this._updateTooltip(o,p);},_updateIcon:function(o,p){j.removeClass(o,'officeStatusNone');j.removeClass(o,'officeStatusAvailable');j.removeClass(o,'officeStatusSporadic');j.removeClass(o,'officeStatusOutOfOffice');switch(p.officeStatus){case k:j.addClass(o,'officeStatusAvailable');break;case l:j.addClass(o,'officeStatusSporadic');break;case m:j.addClass(o,'officeStatusOutOfOffice');break;default:j.addClass(o,'officeStatusNone');break;}},_updateTooltip:function(o,p){var q='';switch(p.officeStatus){case k:q+=h._("AVAILABLE");q+='\n';break;case l:q+=h._("SPORADIC");q+='\n';break;case m:q+=h._("OFF THE GRID");q+='\n';break;default:q+=h._("UNKNOWN");q+='\n';break;}if(p.officeStatusComment)q+=p.officeStatusComment;if(p.officeStatusLocation)q+=' ('+p.officeStatusLocation+')';if(p.officeStatusComment||p.officeStatusLocation)q+='\n';if(p.officeStatusEndDate){var r=i(p.officeStatusEndDate,'M d, Y');q+=h._("Until {date}",[h.param('date',r)]);}o.setAttribute('aria-label',q);o.setAttribute('data-hover','tooltip');}};f.exports=n;},null);
__d('ChatAddToThreadButton.react',['Link.react','ReactComponentWithPureRenderMixin','React','TrackingNodes','cx','fbt'],function a(b,c,d,e,f,g,h,i,j,k,l,m){'use strict';if(c.__markCompiled)c.__markCompiled();var n=j.PropTypes,o=j.createClass({displayName:'ChatAddToThreadButton',mixins:[i],propTypes:{isFBAtWork:n.bool,onClick:n.func,shown:n.bool},render:function(){var p=this.props.isFBAtWork?m._("Add more co-workers to chat"):m._("Add more friends to chat"),q=k.getTrackingInfo(k.types.ADD_TO_THREAD);return (j.createElement(h,{'aria-label':p,className:"addToThread"+(' '+"button")+(!this.props.shown?' '+"hidden_elem":''),'data-ft':q,'data-hover':'tooltip','data-tooltip-alignv':'top',onClick:this.props.onClick}));}});f.exports=o;},null);
__d('ChatArchiveWarning.react',['Image.react','ReactComponentWithPureRenderMixin','React','cx','ix'],function a(b,c,d,e,f,g,h,i,j,k,l){'use strict';if(c.__markCompiled)c.__markCompiled();var m=j.PropTypes,n=j.createClass({displayName:'ChatArchiveWarning',mixins:[i],propTypes:{isFBAtWork:m.bool,shown:m.bool},render:function(){var o=this.props.isFBAtWork?l('images/chat/tab/archive-grey.png'):l('images/chat/tab/archive.png');return (j.createElement(h,{src:o,className:"titanArchiveWarning"+(' '+"button")+(!this.props.shown?' '+"hidden_elem":''),'data-hover':'tooltip','data-tooltip-alignh':'center','aria-label':'All employee-to-employee conversations will be archived'}));}});f.exports=n;},null);
__d('ChatVideoCallButton.react',['Link.react','React','TrackingNodes','FBRTCCallabilityStore','StoreAndPropBasedStateMixin','MercuryIDs','MercuryParticipants','cx'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o){'use strict';if(c.__markCompiled)c.__markCompiled();var p=i.PropTypes,q=i.createClass({displayName:'ChatVideoCallButton',mixins:[l(k,n)],statics:{calculateState:function(r){if(r.isGroupChat)return {user:null,isCallable:true};var s=m.getParticipantIDFromUserID(r.userID),t=n.getOrFetch(s);return {user:t,isCallable:k.isCallable(r.userID)};}},propTypes:{isAudio:p.bool,isGroupChat:p.bool,onClick:p.func,onKeyUp:p.func,shown:p.bool},getClassName:function(){return (!this.props.isAudio?"_1fu3":'')+(this.props.isAudio?' '+"_1fu4":'')+(this.state.isCallable?' '+"_1kza":'')+(' '+"button")+(!this.props.shown?' '+"hidden_elem":'');},getTooltipLabel:function(){var r=this.state.user;if(!r)return undefined;if(this.props.isAudio){return k.voiceCallButtonTooltip(this.props.userID,r.short_name);}else return k.callButtonTooltip(this.props.userID,r.short_name);},render:function(){var r=j.getTrackingInfo(this.props.isAudio?j.types.VIDEOCHAT:j.types.VOICECHAT),s=JSON.stringify({videochat:'call_clicked_bhat_tab'});return (i.createElement(h,{'aria-label':this.getTooltipLabel(),className:this.getClassName(),'data-ft':r,'data-gt':s,'data-hover':'tooltip','data-tooltip-position':'above',onClick:this.props.onClick,onKeyUp:this.props.onKeyUp}));}});f.exports=q;},null);