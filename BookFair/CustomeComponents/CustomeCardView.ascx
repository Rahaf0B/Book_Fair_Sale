<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomeCardView.ascx.cs" Inherits="BookFair.CustomeComponents.CustomeCardView" %>
<style>
    .image-container{
    width:150px;
    }
    .info-container{
    width:100%;
    flex-direction: column;

    height: 100%;
    display: flex;

    justify-content: space-between;
    align-items: stretch;
    }

    .image-sub-info-container{
    display:flex;
    flex-direction:row;
    align-items: center;
    gap:20px;
    }
    .sub-info-container{
    display:flex;
    flex-direction:row;
    justify-content: space-around;
    align-items: center;
    }

    .item-container{
    display:flex;
    flex-direction:row;
    align-items: flex-end;
    height:100%;
    }

    .image-item{
    width:100%;
    object-fit:contain;
    }

    .custome-element-container{
    box-shadow: 1px 1px 15px 2px rgba(230,189,150,0.60);

    border-radius:15px;
    padding:20px;
    }


    .btn-cart{
    border-radius:15px;
    width:120px;

    }
</style>

<dx:ASPxPanel ID="ASPxPanelElementContainerCustome" CssClass="custome-element-container"
    runat="server" Width="450px" Height="300px">

    <PanelCollection>
        <dx:PanelContent>
            <dx:ASPxHiddenField ID="ASPxHiddenFieldId" runat="server"></dx:ASPxHiddenField>


            <div class="item-container">


                <div class="info-container">
                    <div class="image-sub-info-container">

                        <div class="image-container">

                            <dx:ASPxImage ID="ASPxElementImage" CssClass="image-item" runat="server"
                                ShowLoadingImage="true" ImageUrl=""></dx:ASPxImage>

                        </div>

                        <dx:ASPxLabel ID="ASPxElementLabelTitle" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="sub-info-container">


                        <dx:ASPxLabel ID="ASPxElementLabelSubject" runat="server" Text=""></dx:ASPxLabel>

                        <dx:ASPxLabel ID="ASPxElementLabelAuthor" runat="server" Text=""></dx:ASPxLabel>

                    </div>
                    <dx:ASPxLabel ID="ASPxElementLabelPrice" runat="server" Text=""></dx:ASPxLabel>

                </div>
                <dx:ASPxButton ID="ASPxButtonOption" runat="server" Width="120px"
                    CssClass="btn-cart" Text="Add To Cart" UseSubmitBehavior="false"
                    OnClick="CustomControl_ButtonClick">


                </dx:ASPxButton>

            </div>
        </dx:PanelContent>
    </PanelCollection>

</dx:ASPxPanel>