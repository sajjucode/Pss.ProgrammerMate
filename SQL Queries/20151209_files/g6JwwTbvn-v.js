/*!CK:3135049919!*//*1449405556,*/

if (self.CavalryLogger) { CavalryLogger.start_js(["l4tqL"]); }

__d('ReactComposerMediaAttachment.react',['ReactComposerAttachmentType','ReactComposerConfig','ReactComposerContextMixin','ReactComposerDragDropPromptContainer.react','ReactComposerMediaAttachmentButtons.react','ReactComposerPhotoUploadsGridContainer.react','ReactComposerProfilePhotoBlock.react','ReactComposerPropsAndStoreBasedStateMixin','ReactComposerStatusAttachmentMentionsInputWithTagExpansionContainer.react','ReactComposerStatusFooterContainer.react','ReactComposerStore','ReactComposerTaggerSummaryContainer.react','ReactComposerVideoUploadPlaceholderContainer.react','ReactComposerVideoUploadProgressBar.react','ReactComposerStatusUtils','immutable','React','fbt'],function a(b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y){'use strict';if(c.__markCompiled)c.__markCompiled();var z=x.PropTypes,aa=x.createClass({displayName:'ReactComposerMediaAttachment',mixins:[j,o(r)],propTypes:{additionalTaggers:z.arrayOf(z.shape({button:z.element.isRequired,container:z.element.isRequired})),additionalFooterActions:z.arrayOf(z.element),config:i.isRequired,createAlbumLink:z.any,onFilesSelected:z.func.isRequired,onMentionsInputChange:z.func,onMentionsInputFocus:z.func,onPasteRawText:z.func,shouldShowCarouselURLInputArea:z.bool,shouldShowCarouselPreview:z.bool,isSlideshowSelected:z.bool,postButtonModule:z.func,uploads:z.instanceOf(w.List).isRequired,video:z.object},statics:{calculateState:function(ba,ca){return {posting:r.isPosting(ba)};}},render:function(){var ba=this.props.config.attachmentsConfig[h.MEDIA],ca=this.props.uploads.size>0||!!this.props.video||ba.canUploadPhoto&&!this.props.createAlbumLink||this.props.shouldShowCarouselURLInputArea||this.props.shouldShowCarouselPreview||this.props.isSlideshowSelected&&this.props.uploads.size>0,da=null;if(ba.ComposerMediaAttachmentButtonsWithOptions){var ea=ba.ComposerMediaAttachmentButtonsWithOptions;da=x.createElement(ea,{carouselConfig:ba.carouselConfig,createAlbumLink:this.props.createAlbumLink,mediaAcceptParam:this.props.config.mediaAcceptParam,onFilesSelected:this.props.onFilesSelected,showCarouselEntryPoint:ba.showCarouselEntryPoint,showSlideshowEntryPoint:ba.showSlideshowEntryPoint,showUploadPhotosButton:ba.canUploadPhoto,targetData:this.props.config.targetData});}else da=x.createElement(l,{showUploadPhotosButton:ba.canUploadPhoto,createAlbumLink:this.props.createAlbumLink,mediaAcceptParam:this.props.config.mediaAcceptParam,onFilesSelected:this.props.onFilesSelected,targetData:this.props.config.targetData});return (ca?this._getMediaContent():x.createElement('div',null,x.createElement(k,{root:this,config:this.props.config}),da));},componentDidMount:function(){v.handleMarkdownPreview(this.context.composerID,this.context.targetID,this.props.config.attachmentsConfig[h.STATUS]);},_getMediaContent:function(){var ba=this.props.config.attachmentsConfig[h.MEDIA],ca=this.props.config.attachmentsConfig[h.STATUS],da;if(this.props.shouldShowCarouselPreview){var ea=ba.ComposerAttachmentPreviewContainer;da=x.createElement(ea,null);}else if(this.props.shouldShowCarouselURLInputArea){var fa=ba.carouselConfig.PhotoCarouselUtils;da=fa.getPhotoCarouselMediaContent(ba.carouselConfig,this.props.config.nuxConfig);}else if(this.props.isSlideshowSelected){var ga=ba.slideshowConfig.photoUploadsContainer;da=x.createElement(ga,{config:this.props.config,onFilesSelected:this.props.onFilesSelected,uploads:this.props.uploads});}else if(this.props.video){da=x.createElement(t,null);if(this.state.posting)da=x.createElement('div',null,da,x.createElement(u,{progressBar:this.props.videoProgressBar}));}else da=x.createElement(m,{enableFaceboxTagger:!ba.disableFaceboxTagger,disablePhotoEditing:ba.disablePhotoEditing,mediaConfig:ba,nuxConfig:this.props.config.nuxConfig,onFilesSelected:this.props.onFilesSelected,canUploadMultiplePhotos:this.props.config.targetData.targetSupportsMultiplePhotos,uploads:this.props.uploads});var ha=x.createElement(p,{config:this.props.config,onFocus:this.props.onMentionsInputFocus,onChange:this.props.onMentionsInputChange,onPasteRawText:this.props.onPasteRawText,placeholder:this._getInputPlaceholder()}),ia;if(ca.showProfilePic){ia=x.createElement(n,{profilePicSrc:ca.profilePicSrc,profileURI:ca.profileURI},ha);}else ia=ha;var ja=ca.multilingualStatus,ka=ca.multilingualStatus?x.createElement(ja,null):null,la=ca.markdownPreviewAttachment,ma=null;if(la){var na=la.container;ma=x.createElement(na,{prettify:la.prettify});}var oa=ca.shareInNewsFeedToggle,pa=ca.shareInNewsFeedToggle,qa=ca.shareInNewsFeedToggle?x.createElement(pa,null):null;return (x.createElement('div',null,x.createElement(k,{root:this,config:this.props.config}),ia,ka,ma,x.createElement(s,null),da,qa,x.createElement(q,{additionalTaggers:this.props.additionalTaggers,additionalFooterActions:this.props.additionalFooterActions,attachmentsConfig:this.props.config.attachmentsConfig,audienceXHP:this.props.config.audienceXHP,config:this.props.config,isCameraIconEnabled:!this.props.shouldShowCarouselURLInputArea,locationTaggerPlaceholder:this._getLocationTaggerPlaceholder(),mediaAcceptParam:this.props.config.mediaAcceptParam,peopleTaggerPlaceholder:this._getPeopleTaggerPlaceholder(),postButtonModule:this.props.postButtonModule,taggersConfig:this.props.config.taggersConfig,targetData:this.props.config.targetData})));},_getLocationTaggerPlaceholder:function(){if(!!this.props.video)return y._("Where was this taken?");if(this.props.uploads.size>1)return y._("Where were these photos taken?");if(this.props.uploads.size===1)return y._("Where was this photo taken?");return null;},_getPeopleTaggerPlaceholder:function(){if(!!this.props.video||this.props.uploads.size>0)return y._("Who were you with?");return null;},_getInputPlaceholder:function(){var ba=this.props.config.attachmentsConfig[h.MEDIA];if(!!this.props.video){return y._("Say something about this video...");}else if(this.props.isSlideshowSelected){return y._("Say something about this slideshow...");}else if(this.props.uploads.size>1){return y._("Say something about these photos...");}else if(this.props.shouldShowCarouselURLInputArea||this.props.shouldShowCarouselPreview){var ca=ba.carouselConfig.PhotoCarouselUtils;return ca.getInputPlaceHolder(ba.carouselConfig,this.props.shouldShowCarouselPreview);}else return y._("Say something about this photo...");}});f.exports=aa;},null);