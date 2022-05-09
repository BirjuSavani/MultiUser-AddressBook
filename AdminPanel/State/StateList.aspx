<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row">
        <div class="col-md-6">
            <h2>State List</h2>
            
        </div>
        <div class="col-md-6" style="text-align: right">
                <br />
                <asp:HyperLink runat="server" ID="HyperLink7" Text="StateAdd" class="btn btn-outline-info button1" NavigateUrl="~/AdminPanel/State/Add" Style="color: black"></asp:HyperLink>            </div>
    </div>
    <div class="row">
        <div class="col-md-12" style="color:red">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
        </div>
    </div><br />
    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvState" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvState_RowCommand">
                <Columns>
                    <%--<asp:BoundField DataField="StateID" HeaderText="ID" />--%>
                    <asp:BoundField DataField="StateName" HeaderText="State Name" />
                    <asp:BoundField DataField="StateCode" HeaderText="State Code" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ??? ');" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID").ToString() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/State/Edit/" + CommonDropDownFillMethods.Base64encode(Eval("StateID").ToString().Trim()) %>' CssClass="btn btn-dark btn-sm"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
</asp:Content>

