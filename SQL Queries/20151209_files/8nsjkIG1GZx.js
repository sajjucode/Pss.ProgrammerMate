/*!CK:1148874379!*//*1448389637,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["VDR8O"]); }

__d('ReactComposerInstantMediaAttachmentSelector.react',['ReactComposerContextMixin','ReactComposerMediaAttachmentSelector.react','ComposerTargetData','Bootloader','DOM','DOMContainer.react','Event','FileInput.react','FileInput','ReactComponentWithPureRenderMixin','React','ReactDOM','SubscriptionsHandler','cx','fbt'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v){if(c.__markCompiled)c.__markCompiled();var w=r.PropTypes,x=r.createClass({displayName:'ReactComposerInstantMediaAttachmentSelector',_prefillFileInput:null,_subscriptions:null,mixins:[h,q],propTypes:{disableFaceRecognition:w.bool.isRequired,fileInputDOM:w.any,mediaAcceptParam:w.shape({photos:w.string,both:w.string}).isRequired,onClick:w.func.isRequired,onFilesSelected:w.func.isRequired,photoLimit:w.number.isRequired,targetData:w.instanceOf(j).isRequired},componentDidMount:function(){if(this.props.fileInputDOM){var y=l.find(s.findDOMNode(this),'input[type="file"]');if(y.files&&y.files.length>0)this._uploadExistingFiles(y.files);this._prefillFileInput=new p(s.findDOMNode(this.refs.prefillContainer),s.findDOMNode(this.refs.prefillSelector),y);this._subscriptions=new t();this._subscriptions.addSubscriptions(n.listen(y,'change',this._onFilesSelected));}},componentWillUnmount:function(){this._subscriptions&&this._subscriptions.release();},render:function(){var y=this.props.fileInputDOM;if(y)return (r.createElement('span',{className:"_yt4"+(' '+"_m"),onClick:this.props.onClick,ref:'prefillContainer'},r.createElement(i,{label:v._("Add Photos\/Video"),ref:'prefillSelector'}),r.createElement(m,null,y)));return (r.createElement(o,{accept:this.props.mediaAcceptParam.both,containerClassName:"_yt4",display:'inline',multiple:this.props.targetData.targetSupportsMultiplePhotos,name:'composer_photo[]',onChange:this._onFilesSelected,onClick:this.props.onClick,ref:'fileInput',role:'button',tabIndex:'0','data-testid':'instant-media-attachment-selector'},r.createElement(i,{label:v._("Add Photos\/Video")})));},_onFilesSelected:function(event){this.props.onFilesSelected(event);k.loadModules(["ReactComposerMediaUtils"],(function(y){y.clearInput(this._prefillFileInput||this.refs.fileInput.getFileInput());}).bind(this));},_uploadExistingFiles:function(y){k.loadModules(["ReactComposerMediaUtils","ReactComposerPhotoUploader"],(function(z,aa){return (z.uploadPhotosOrVideo(this.context.composerID,Array.prototype.slice.call(y),new aa(this.context,this.props.photoLimit,{disableFaceRecognition:this.props.disableFaceRecognition}),this.props.targetData.targetSupportsMultiplePhotos));}).bind(this));}});f.exports=x;},null);
__d('ReactComposerMediaFilePickerMixin',['ReactComposerContextMixin','Bootloader','invariant'],function a(b,c,d,e,f,g,h,i,j){if(c.__markCompiled)c.__markCompiled();var k={mixins:[h],componentWillMount:function(){!this.props.photoLimit?j(0):undefined;!this.props.targetData?j(0):undefined;},_onFileInputClick:function(l){i.loadModules(["ReactComposerAttachmentLoader","ReactComposerAttachmentType","ReactComposerMediaInitUtils","ReactComposerPhotoUploadActions","ReactComposerLoggingStore"],(function(m,n,o,p,q){p.inputClicked(this.context.composerID);m.load(this.context.composerID,n.MEDIA,typeof l==='function'?l:o.bootload,o.getBootstrapURI(this.context.composerID,this.context.composerType,this.context.targetID,this.context.actorID));}).bind(this));},_onFilesSelected:function(event){i.loadModules(["ReactComposerAttachmentType","ReactComposerAttachmentActions","ReactComposerPhotoUploader","ReactComposerMediaUtils"],(function(l,m,n,o){var p=new n(this.context,this.props.photoLimit,{disableFaceRecognition:this.props.disableFaceRecognition});m.selectAttachment(this.context.composerID,l.MEDIA,true);o.uploadPhotosOrVideoFromTarget(this.context.composerID,event.target,p,this.props.targetData.targetSupportsMultiplePhotos);}).bind(this));}};f.exports=k;},null);
__d('ReactComposerInstantMediaAttachmentSelectorContainer.react',['ReactComposerInstantMediaAttachmentSelector.react','ReactComposerMediaFilePickerMixin','ComposerTargetData','ReactComponentWithPureRenderMixin','React','curry'],function a(b,c,d,e,f,g,h,i,j,k,l,m){if(c.__markCompiled)c.__markCompiled();var n=l.PropTypes,o=l.createClass({displayName:'ReactComposerInstantMediaAttachmentSelectorContainer',mixins:[k,i],propTypes:{bootload:n.func,disableFaceRecognition:n.bool.isRequired,fileInputPrefillConfig:n.object,mediaAcceptParam:n.shape({photos:n.string,both:n.string}).isRequired,photoLimit:n.number.isRequired,targetData:n.instanceOf(j).isRequired},getDefaultProps:function(){return {disableFaceRecognition:false};},render:function(){var p=this.props.prefillConfig&&this.props.prefillConfig.instantMediaSelector&&this.props.prefillConfig.instantMediaSelector.fileInputDOM;return (l.createElement(h,babelHelpers._extends({},this.props,{fileInputDOM:p,onClick:m(this._onFileInputClick,this.props.bootload),onFilesSelected:this._onFilesSelected})));}});f.exports=o;},null);
__d("XNotesComposerController",["XController"],function a(b,c,d,e,f,g){c.__markCompiled&&c.__markCompiled();f.exports=c("XController").create("\/notes\/composer\/",{page_id:{type:"Int"}});},null);
__d('ReactComposerNotesAttachmentSelector.react',['ReactComposerAttachmentSelectorContainer.react','ReactComposerAttachmentType','ReactComposerContextMixin','AsyncRequest','Bootloader','ReactComponentWithPureRenderMixin','React','XNotesComposerController','fbt','ix'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q){if(c.__markCompiled)c.__markCompiled();var r=n.PropTypes,s=n.createClass({displayName:'ReactComposerNotesAttachmentSelector',mixins:[j,m],propTypes:{label:r.string},getDefaultProps:function(){return {label:p._("Write Note")};},render:function(){return (n.createElement(h,{attachmentID:i.NOTES,label:this.props.label,icon:q('/images/litestand/composer/icons/note.png'),onSelected:this._onSelected}));},_onSelected:function(){l.loadModules(["AsyncDialog"],(function(t){var u=o.getURIBuilder().getURI(),v=new k(u).setMethod('POST').setStatusElement(this.context.composerID);t.send(v);}).bind(this));}});f.exports=s;},null);
__d('ReactComposerFeedBootloader',['Bootloader'],function a(b,c,d,e,f,g,h){'use strict';if(c.__markCompiled)c.__markCompiled();var i={statusAttachment:function(j){h.loadModules(["ReactComposerStatusAttachmentContainer.react","ReactComposerFeedPostButtonContainer.react"],j);},mediaAttachment:function(j){h.loadModules(["ReactComposerMediaAttachmentContainer.react","ReactComposerFeedMediaPostButtonContainer.react"],j);},qandaAttachment:function(j){h.loadModules(["ReactComposerQAndAAttachmentContainer.react","ReactComposerFeedMediaPostButtonContainer.react"],j);}};f.exports=i;},null);
__d('ReactFeedComposer.react',['ReactComposer.react','ReactComposerAttachmentType','ReactComposerBodyContainer.react','ReactComposerConfig','ReactComposerContextConfig','ReactComposerContextProviderMixin','ReactComposerFeedBootloader','ReactComposerLazyHeader.react','ReactComposerMediaAttachmentSelector.react','ReactComposerInstantMediaAttachmentSelectorContainer.react','ReactComposerMediaLazyAttachment.react','ReactComposerNotesAttachmentSelector.react','ReactComposerMLEAttachmentSelector.react','ReactComposerMLELazyAttachment.react','ReactComposerQAndAAttachmentSelector.react','ReactComposerQAndALazyAttachment.react','ReactComposerStatusAttachmentSelector.react','ReactComposerStatusLazyAttachment.react','Bootloader','DOMContainer.react','React','LitestandComposer','cx','fbt'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,aa,ba,ca,da,ea){if(c.__markCompiled)c.__markCompiled();var fa=ba.createClass({displayName:'ReactFeedComposer',mixins:[m],propTypes:{contextConfig:l.isRequired,config:k.isRequired},componentDidMount:function(){ca.initComposer(this.props.contextConfig.composerID);},statics:{preload:function(){}},render:function(){var ga=this._getAdditionalAttachmentComponents(),ha=ga[0],ia=ga[1];return (ba.createElement(h,{className:"_5n2b",loggingConfig:this.props.config.loggingConfig},ba.createElement(o,{showDelimiter:true},ba.createElement(x,{label:ea._(["Update Status","155d6cd2b97f05fd0d45ff038fb8f47d"])}),ha),ba.createElement(j,{expanded:this.props.config.showExpandedComposer},ba.createElement(y,{bootloader:n,config:this.props.config,selected:true,expanded:this.props.config.showExpandedComposer}),ia)));},_getAdditionalAttachmentComponents:function(){var ga=this.props.config.attachmentsConfig,ha=[],ia=[],ja=ga[i.ALBUM].enabled,ka=ga[i.NOTES].enabled,la=ga[i.QANDA].enabled,ma=ga[i.MLE].enabled;ha.push(this._getMediaAttachmentSelector());ia.push(ba.createElement(r,{key:'media',config:this.props.config,bootloader:n}));if(ja)ha.push(ba.createElement(aa,{key:'album',display:'block'},ga[i.ALBUM].createAlbumLink));if(ka)ha.push(ba.createElement(s,{key:'notes'}));if(la){ha.push(ba.createElement(v,{key:'qanda'}));ia.push(ba.createElement(w,{key:'qanda',config:this.props.config,bootloader:n}));}if(ma){ha.push(ba.createElement(t,{key:'mle',label:ea._("Add a Life Event")}));ia.push(ba.createElement(u,{key:'mle',config:this.props.config}));}return [ha,ia];},_getMediaAttachmentSelector:function(){var ga=this.props.config.attachmentsConfig[i.MEDIA];if(ga.openFileBrowserImmediately)return (ba.createElement(q,{key:'media',disableFaceRecognition:ga.disableFaceboxTagger,mediaAcceptParam:this.props.config.mediaAcceptParam,photoLimit:ga.photoLimit,targetData:this.props.config.targetData,bootload:function(ha){return z.loadModules(["ReactComposerMediaAttachmentContainer.react","ReactComposerFeedMediaPostButtonContainer.react"],ha);}}));return (ba.createElement(p,{key:'media',label:ea._("Add Photos\/Video")}));}});f.exports=fa;},null);