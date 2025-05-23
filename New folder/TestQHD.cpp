#include<iostream>
#include<iomanip>
#include<string>
using namespace std;
struct CanRuou{
	string NhanHieu;
	int DungTich;
	int Gia;
};
void HienThi(CanRuou cr[],int n){
	cout<<left<<setw(15)<<"Nhan Hieu"<<setw(15)<<"Dung Tich"<<
	setw(15)<<"Gia"<<endl;
	for(int i=0;i<n;i++){
		cout<<left<<setw(15)<<cr[i].NhanHieu<<setw(15)<<cr[i].DungTich<<
		setw(15)<<cr[i].Gia<<endl;
	}
}
int QHD(CanRuou cr[],int n,int s,CanRuou KetQua2[],int& dem2){
	int dp[n+1][s+1];
	bool choose[n+1][s+1];
	for(int i=0;i<=n;i++){
		for(int j=0;j<=s;j++){
			dp[i][j]=0;
			choose[i][j]=false;
		}
	}
	for(int i=1;i<=n;i++){
		for(int j=0;j<=s;j++){
			if(cr[i-1].DungTich<=j){
				int kchon = dp[i-1][j];
				int chon = dp[i-1][j-cr[i-1].DungTich]+cr[i-1].Gia;
				if(chon>kchon){
					dp[i][j]=chon;
					choose[i][j]= true;
				}
				else{
					dp[i][j]=kchon;
				} 
			}
			else{
				dp[i][j]=dp[i-1][j];
			}
		}
	}
	int i=n,j=s;
	while(i>0&&j>0){
		if(choose[i][j]){
			KetQua2[dem2++]=cr[i-1];
			j = j - cr[i-1].DungTich;
		}
		i--;
	}
	return dp[n][s];
}
int main(){
	int n = 6 ;
    CanRuou cr[n] = {
        {"Vang phap",2,120000},
        {"Nho my",3,320000},
        {"Tao meo",5,120000},
        {"ruou man",2,900000},
        {"ruou ran",4,100000},
        {"con",10,10000},
    };
    int s = 10;
    int dem2 = 0;
    CanRuou KetQua2[n];
    int Tong = QHD(cr,n,s,KetQua2,dem2);
    cout<<"Tong max = "<<Tong<<endl;
    cout<<"Lay dc "<<dem2<<" can ruou"<<endl;
    HienThi(KetQua2,dem2);
    return 0;
}
