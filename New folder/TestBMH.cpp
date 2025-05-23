#include<iostream>
#include<iomanip>
#include<string>
using namespace std;
struct MonHoc{
	string Ten;
	string Ma;
	int Tin;
	int Tien;
};
void HienThi(MonHoc mh[],int n){
	cout<<left<<setw(15)<<"Ten Mon Hoc"<<setw(15)<<"Ma Mon"<<
	setw(15)<<"So Tin"<<setw(15)<<"So Tien"<<endl;
	for(int i=0;i<n;i++){
		cout<<left<<setw(15)<<mh[i].Ten<<setw(15)<<mh[i].Ma<<
		setw(15)<<mh[i].Tin<<setw(15)<<mh[i].Tien<<endl;
	}
}
void SapXep(MonHoc mh[],int n){
	for(int i=0;i<n;i++){
		for(int j=i+1;j<n;j++){
			if(mh[i].Tien>mh[j].Tien){
				swap(mh[i],mh[j]);
			}
		}
	}
}
void ThamLam(MonHoc mh[],int n,int p,MonHoc KetQua[],int& dem){
	SapXep(mh,n);
	if(mh[0].Tien>p){
		cout<<"Voi so tien p k mua dc gi ca"<<endl;
	}
	for(int i=0;i<n;i++){
		if(mh[i].Tien <= p){
			KetQua[dem++] = mh[i];
			p = p - mh[i].Tien;
		}
	}
}
void BMH(const MonHoc mh[],int n,const string& partern,MonHoc KetQua2[],int& dem2){
	int m = partern.size();
	if(m==0){
		cout<<"Chuoi con khong hop le";
		return;
	}
	int shift[256];
	for(int i=0;i<256;i++){
		shift[i]=m;
	}
	for(int i=0;i<m-1;i++){
		shift[(unsigned char)partern[i]]=m-i-1;
	}
	for(int i=0;i<n;i++){
		if(mh[i].Ten.size()<m) continue;
		for(int j=0;j<=mh[i].Ten.size()-m;j++){
			int idx = m - 1;
			while(idx > -1 && mh[i].Ten[j+idx]==partern[idx]){
				idx--;
			}
			if(idx<0){
				KetQua2[dem2] = mh[i];
				dem2++;
				break;
			}
			else{
				j = j + shift[(unsigned char)mh[i].Ten[j+idx]];
			}
		}
	}
}
int main(){
	int n = 6;
	MonHoc mh[n] = {
		{"Toan","IT01",3,1000},
		{"Van","IT02",3,3000},
		{"Anh","IT03",3,2000},
		{"Ly","IT04",3,5000},
		{"Full Toan","IT05",3,7000},
		{"Toan Cao Cap","IT06",3,4000},
	};
	int dem = 0;
	MonHoc KetQua[n];
	int p = 10000;
	ThamLam(mh,n,p,KetQua,dem);
	cout<<"Mua dc "<<dem<<" mon hoc"<<endl;
	HienThi(KetQua,dem);
	int dem2 = 0;
	MonHoc KetQua2[n];
	string partern = "Toan";
	BMH(mh,n,partern,KetQua2,dem2);
	cout<<"Co "<<dem2<<" mon Toan"<<endl;
	HienThi(KetQua2,dem2);
}
