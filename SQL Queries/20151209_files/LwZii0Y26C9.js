/*!CK:3481066225!*//*1448988909,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["ase5g"]); }

__d('VideoClosedCaptionsControl.react',['AbstractButton.react','Image.react','React','cx','fbt','ix','shallowCompare'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o,p;'use strict';var q=j.PropTypes;o=babelHelpers.inherits(r,j.Component);p=o&&o.prototype;r.prototype.shouldComponentUpdate=function(s,t){return n(this,s,t);};r.prototype.render=function(){var s=!this.props.areClosedCaptionsActive?"_2bs_":'',t=j.createElement(i,{className:s,src:m('images/video/player/controls/hq_icons/captions.png')});return (j.createElement(h,babelHelpers._extends({'aria-label':l._("Toggle closed captions"),tabIndex:this.props.tabIndex,type:'button'},this.props,{className:"_zbd",onClick:this.props.onToggleClosedCaptions,image:t})));};function r(){o.apply(this,arguments);}r.propTypes={areClosedCaptionsActive:q.bool,onToggleClosedCaptions:q.func,tabIndex:q.string};f.exports=r;},null);
__d('VideoQualityControl.react',['AbstractButton.react','Image.react','React','cx','fbt','ix','shallowCompare'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n){if(c.__markCompiled)c.__markCompiled();var o,p;'use strict';var q=j.PropTypes;o=babelHelpers.inherits(r,j.Component);p=o&&o.prototype;r.prototype.shouldComponentUpdate=function(s,t){return n(this,s,t);};r.prototype.render=function(){var s=!this.props.isHD?"_2bs_":'',t=j.createElement(i,{className:s,src:m('images/video/player/controls/hq_icons/hd.png')});return (j.createElement(h,{'aria-label':l._("Toggle HD"),tabIndex:this.props.tabIndex,type:'button',className:"_zbd",image:t,onClick:this.props.onToggleHD}));};function r(){o.apply(this,arguments);}r.propTypes={isHD:q.bool,onToggleHD:q.func,tabIndex:q.string};f.exports=r;},null);